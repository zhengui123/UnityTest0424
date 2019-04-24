using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCamera : MonoBehaviour
{
    public GameObject mainCamra;
    public Camera shexianCamra;

    public float startCameraZ;
    public float zhedangCameraZ = 1;
    public float workSpeed = 0.1f;
    public float startWorkSpeed = 0.1f;

    public float rotySpeed = 0.1f;
    public float rotxSpeed = 0.1f;

    public float rotx = 0;
    public float roty = 0;
	void Start ()
	{
        if(mainCamra == null)
	        mainCamra = Camera.main.GetComponent<Camera>().gameObject;
	    startCameraZ = mainCamra.transform.localPosition.z;
	}

    private RaycastHit hit;
    private Vector3 endPos;
	void Update ()
	{
        workSpeed = startWorkSpeed;

        //transform.localPosition += transform.localRotation * Vector3.forward * workSpeed;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        #region 上坡下坡判断 调整workspeed
        Vector3 newPos = transform.localPosition + new Vector3(v * transform.forward.x * workSpeed + h * transform.right.x * workSpeed, 0, v * transform.forward.z * workSpeed + h * transform.right.z * workSpeed);
        newPos.y = SampleHeight(newPos);

        Vector3 heropos = transform.localPosition;
        heropos .y= SampleHeight(transform.localPosition);

        Debug.DrawLine(heropos, newPos, Color.black);

        float c = workSpeed;
        float b = newPos.y - heropos.y;

        if (b > 0)
        {
            //float a = Mathf.Sqrt(Mathf.Pow(c, 2) - Mathf.Pow(b, 2));
            float angle = Vector3.Angle(transform.forward, (newPos - heropos));
            workSpeed = (90 - angle) / 90 * startWorkSpeed;
        }
        else if(b < 0)
        {
            float angle = Vector3.Angle(transform.forward, (newPos - heropos));
            Debug.Log(angle);
            workSpeed =  angle / 90 * startWorkSpeed;
        }
        #endregion

        endPos = transform.localPosition += new Vector3(v * transform.forward.x * workSpeed + h * transform.right.x * workSpeed, 0, v * transform.forward.z * workSpeed + h * transform.right.z * workSpeed);
        endPos.y = SampleHeight(endPos);
        transform.localPosition = endPos;


        if (Input.GetMouseButton(0))
	    {
	        rotx -= rotySpeed * Input.GetAxis("Mouse Y");
	        roty += rotxSpeed * Input.GetAxis("Mouse X");
            FinishRot(rotx);
	        FinishRot(roty);
            transform.localRotation =Quaternion.Euler(rotx,roty,0);
	    }
        if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2)),out hit,1000))
        {
            if (hit.transform.tag != "Player")
            {
                GetCamera(zhedangCameraZ);

            }
        }
	    if (Physics.Raycast(shexianCamra.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)), out hit, 1000))
	    {
	        if (hit.transform.tag == "Player")
	        {

	            GetCamera(-zhedangCameraZ);
	        }
	    }


    }

    /// <summary>
    /// 拉近（远）摄像机
    /// </summary>
    /// <param name="i"></param>
    void GetCamera(float i)
    {
        Vector3 flag = mainCamra.transform.localPosition;
        flag.z -= i;
        flag.z = flag.z >= startCameraZ ? flag.z:startCameraZ;
        mainCamra.transform.localPosition = Vector3.MoveTowards(mainCamra.transform.localPosition,flag,Time.deltaTime * 5f);
    }

    /// <summary>
    /// 整理角度
    /// </summary>
    /// <param name="i"></param>
    void FinishRot(float i)
    {
        i = i > 360 ? i - 360 : i;
        i = i < -360 ? i + 360 : i;
    }

    public float SampleHeight(Vector3 point)
    {
        Vector3 sample = point;
        sample.y += 20f;
        Ray ray = new Ray(sample, Vector3.down);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform.tag == "Plane")
            {
                return hit.point.y + transform.localScale.y;
            }
        }
        return point.y;
    }
}
