using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class MaterialTest : MonoBehaviour
{

    public Renderer r;
	void Start ()
	{
		//GetMaterial(r).color = Color.black;
	    //r.material.color = Color.white;
	    r.sharedMaterial.color = Color.red;

    }

    void Update () {
		
	}

    public static Material GetMaterial(Renderer render)
    {
#if UNITY_EDITOR
        return render.material;
#else
        return render.sharedMaterial;
#endif

    }
}
