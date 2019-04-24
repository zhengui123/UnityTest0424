using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCalculation : MonoBehaviour {

    public float distance = 5f;
    public Transform target;
	void Start ()
    {
        
    }

    void Update()
    {
        Quaternion q1 = Quaternion.Euler(new Vector3(0, 30, 0)) * transform.rotation;
        Vector3 v1 = q1 * Vector3.forward * distance + transform.position;
        Quaternion q2 = Quaternion.Euler(new Vector3(0, -30, 0)) * transform.rotation;
        Vector3 v2 = q2 * Vector3.forward * distance + transform.position;
        Vector3 v0 = transform.rotation * Vector3.forward * distance + transform.position;

        Debug.DrawLine(transform.position, v1, Color.red);
        Debug.DrawLine(transform.position, v2, Color.red);
        Debug.DrawLine(transform.position, v0, Color.red);
        Debug.DrawLine(v1, v0, Color.red);
        Debug.DrawLine(v2, v0, Color.red);


        if (IsIn(target.position, v0, transform.position, v2) || IsIn(target.position, v0, transform.position, v1))
        {
            Debug.Log("In");
        }
        else
        {
            Debug.Log("Not In");
        }
    }

    public float TriangleArea(Vector3 v0, Vector3 v1, Vector3 v2)
    {
       

        return  Mathf.Abs(((v0.x * (v1.z - v2.z) + v1.x * (v2.z - v0.z) + v2.x * (v0.z - v1.z)) / 2));

    }

    public bool IsIn(Vector3 _target,Vector3 v0, Vector3 v1, Vector3 v2)
    {
        float startT = TriangleArea( v0, v1,v2);
        float targetT = TriangleArea(_target,v1, v2)+ TriangleArea(v0,_target,v2) + TriangleArea(v0, v1,_target);
        if (Mathf.Abs(startT - targetT) <= 0.01f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
