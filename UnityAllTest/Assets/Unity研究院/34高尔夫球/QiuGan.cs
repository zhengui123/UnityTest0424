using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QiuGan : MonoBehaviour
{
    public GameObject qiu;
    public GameObject qiugan;
    public Transform transformPos1;
    public Transform transformPos2;

    void Start ()
	{
	    
    }

    private bool isHit = false;
    private bool isGetPos2 = false;
	void Update ()
	{

	    if (Input.GetKey(KeyCode.A))
	    {
	        qiugan.transform.RotateAround(qiu.transform.position, Vector3.up, 10 * Time.deltaTime);
        }

	    if (Input.GetKey(KeyCode.D))
	    {
	        qiugan.transform.RotateAround(qiu.transform.position, Vector3.up, -10 * Time.deltaTime);
	    }

        if (Input.GetKeyDown(KeyCode.K))
	    {
	        isGetPos2 = false;
	        isHit = true;
	    }

        if (isHit)
	    {
	        if (transform.rotation != transformPos2.rotation && !isGetPos2)
	        {
	            transform.rotation = Quaternion.Lerp(transform.rotation, transformPos2.rotation, Time.deltaTime * 2f);
	        }
	        else
	            isGetPos2 = true;

	        if (isGetPos2)
	        {
	            transform.rotation = Quaternion.Lerp(transform.rotation, transformPos1.rotation, Time.deltaTime * 2f);
	            if (transform.rotation == transformPos1.rotation)
	            {
	                isHit = false;
	                Vector3 vecsphere = qiugan.transform.localRotation * (Vector3.forward);
	                qiu.GetComponent<Rigidbody>().AddForce(vecsphere * 500, ForceMode.Force);
                }

	        }
        }

	    DrawHitLine();
	   
    }

    public LineRenderer lineRenderer;
    public Vector3 hitPoint;
    void DrawHitLine()
    {
        hitPoint = qiugan.transform.localRotation * (Vector3.forward);

        hitPoint = (hitPoint.normalized * 100) + qiu.transform.localPosition;
        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, qiu.transform.localPosition);
        lineRenderer.SetPosition(1, hitPoint);

    }


}
