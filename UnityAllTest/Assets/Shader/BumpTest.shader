﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/BumpTest"{
	ProPerties {
		_MainTex("Base (RGB)", 2D) = "White" {}
	_TexColor("Tex Color", Color) = (1, 1, 1, 1)
	_Bump("Bump", 2D) = "bump" {}
	_Snow("Snow Level", Range(0,1)) = 0
	_SnowColor("Snow Color", Color) = (1.0, 1.0, 1.0, 1.0)
	_SnowDirection("Snow Direction", Vector) = (0, 1 ,0)
	_SnowDepth("Snow Depth", Range(0,0.3)) = 0.1

	}

		SubShader{
		Tags {"RenderType" = "Opaque"}
		LOD 200

		CGPROGRAM
#pragma surface surf  CustomDiffuse vertex:vert  

		sampler2D _MainTex;
	float4 _TexColor;
	sampler2D _Bump;

	float _Snow;
	float4 _SnowColor;
	float4 _SnowDirection;
	float _SnowDepth;

	void vert(inout appdata_full v)
	{
		float4 sn = mul(transpose(unity_ObjectToWorld), _SnowDirection);
		if (dot(v.normal, sn.xyz) >= lerp(1, -1, (_Snow * 2) / 3)){
		v.vertex.xyz += (sn.xyz + v.normal) * _SnowDepth * _Snow;
		}
	}

	struct Input {
		float2 uv_MainTex;
		float4 uv_TexColor;
		float2 uv_Bump;
		float3 worldNormal; INTERNAL_DATA
		
	};

	void surf(Input IN, inout SurfaceOutput o) {

		half4 c = tex2D(_MainTex, IN.uv_MainTex);
		o.Normal = UnpackNormal(tex2D(_Bump, IN.uv_Bump));

		if (dot(WorldNormalVector(IN, o.Normal), _SnowDirection.xyz) > lerp(1, -1, _Snow))
		{
			o.Albedo = _SnowColor.rgb;
		}
		else
		{
			o.Albedo = c.rgb * _TexColor.xyz;
		}
		
		o.Alpha = c.a * _TexColor.w;
	}
	

//SurfaceOutput s这个就是经过表面计算函数surf处理后的输出，，
//fixed3 lightDir是光线的方向，
//fixed atten表示光衰减的系数
	inline float4 LightingCustomDiffuse(SurfaceOutput s, fixed3 lightDir, fixed atten) {

		float difLight = max(0, dot(s.Normal, lightDir));
		float hLambert = difLight * 0.5 + 0.5;
		float4 col;
		col.rgb = s.Albedo * _LightColor0.rgb * (difLight * atten * 2);
		//col.rgb = s.Albedo * _LightColor0.rgb *(hLambert * atten * 2);
		col.a = s.Alpha;
		return col;
	}

	ENDCG

	}
		FallBack "Diffuse"

}