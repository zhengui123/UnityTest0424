using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;

    private int lineLength = 4; 
    Vector3 v1 = new Vector3(0f, 0f, 0f);
    Vector3 v2 = new Vector3(0f, 1f, 0f);
    Vector3 v3 = new Vector3(0f, 0f, 1f);
    Vector3 v4 = new Vector3(1f, 0f, 0f);


    void Start ()
    {
        lineRenderer.positionCount = lineLength;
        lineRenderer.SetPosition(0, v1);
        lineRenderer.SetPosition(1, v2);
        lineRenderer.SetPosition(2, v3);
        lineRenderer.SetPosition(3, v4);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
