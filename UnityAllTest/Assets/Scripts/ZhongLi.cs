using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class ZhongLi : MonoBehaviour {

    public Text text;
    public GameObject qiuObj;
    private float qiuX;
    private float qiuY;
    public  float MaxX;
    public float MaxY;

    public float topBorder;
    public float leftBorder;
    public float rightBorder;
    public float bottomBorder;

	void Start ()
    {
        MaxX = Screen.width;
        MaxY = Screen.height;

        Vector3 leftBtm = Camera.main.ViewportToWorldPoint(new Vector3(0,0,Mathf.Abs(-Camera.main.transform.position.z)));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Mathf.Abs(-Camera.main.transform.position.z)));
        rightBorder = rightTop.x;
        leftBorder = leftBtm.x;
        topBorder = rightTop.y;
        bottomBorder = leftBtm.y;

	}
	
	// Update is called once per frame
	void Update ()
    {
        text.text = Input.acceleration.ToString();
        qiuX += Input.acceleration.x * 0.1f;
        qiuY += Input.acceleration.y * 0.1f;
        qiuObj.transform.position =SphereBorder( new Vector3(qiuX,qiuY,0) );


	}

    Vector3 SphereBorder(Vector3 spherePos)
    {
        if (spherePos.x >= rightBorder)
            spherePos.x = rightBorder;
        else if (spherePos.x <= leftBorder)
            spherePos.x = leftBorder;
        if (spherePos.y >= topBorder)
            spherePos.y = topBorder;
        else if (spherePos.y <= bottomBorder)
            spherePos.y = bottomBorder;

        return spherePos;
    }
}
