using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour {

    public MeshFilter meshFilter;
    public Mesh mesh;
    void Start()
    {
        mesh = meshFilter.mesh;

        //6个顶点的面
        mesh.vertices = new Vector3[] { new Vector3(5, 0, 0), new Vector3(0, 5, 0), new Vector3(0, 0, 5), new Vector3(0, 0, 5), new Vector3(0, -5, 0), new Vector3(0, 0, -5) };
        //三角形索引 对应定点数 索引和定点数量不需要一样
        mesh.triangles = new int[] { 0, 1, 2, 3, 4, 5 };


        //贴图uv平铺
        mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(0, 5), new Vector2(5, 5), new Vector2(0, 0), new Vector2(0, 1), new Vector2(1, 1) };
    }
      
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
