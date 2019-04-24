using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public GameObject rotY;
    public GameObject rotX;
    public Camera mainCamera;

    public float screenWidth;
    public float screenHeight;

    public float fieldOfViewSpeed = 2f;
    public float fieldMin = 5f;
    public float fieldMax = 90f;


    private Vector3 startScreenPos;
    private Vector3 newScreenPos;

    private float moveX;
    private float moveY;
	void Start ()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
	}

    private Vector3 flagY;
    private Vector3 flagX;

    void Update ()
    {

        if (Input.GetMouseButtonDown(2))
        {
            startScreenPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            MouseMoveCamera();
        }

        else if (Input.GetMouseButtonDown(1))
        {
            startScreenPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(1))
        {
            MouseRotCamera();
        }

        MouseOfFieldOfView();

    }

    public float moveXMin = -100f;
    public float moveXMax = 100f;
    public float moveYMin = 0f;
    public float moveYMax = 100f;
    public float moveSpeed = 2f;
    private Vector3 flagMove;
    public void MouseMoveCamera(int i = 0)
    {
        newScreenPos = Input.mousePosition;
        moveX = newScreenPos.x - startScreenPos.x;
        moveY = newScreenPos.y - startScreenPos.y;

        flagMove = rotX.transform.localPosition;
        flagMove.x += moveX / screenWidth * moveSpeed;
        flagMove.y -= moveY / screenHeight * moveSpeed;
        if (flagMove.x <= moveXMin)
            flagMove.x = moveXMin;
        if (flagMove.x >= moveXMax)
            flagMove.x = moveXMax;
        if (flagMove.y <= moveYMin)
            flagMove.y = moveYMin;
        if (flagMove.y >= moveYMax)
            flagMove.y = moveYMax;
        rotX.transform.localPosition = flagMove;

    }

    /// <summary>
    /// 鼠标控制旋转摄像头 
    /// </summary>
    public void MouseRotCamera()
    {
        newScreenPos = Input.mousePosition;
        moveX = newScreenPos.x - startScreenPos.x;
        moveY = newScreenPos.y - startScreenPos.y;

        flagX = ClearVector3(rotX.transform.eulerAngles);
        flagY = ClearVector3(rotY.transform.eulerAngles);

        flagY.y += (moveX / screenWidth * 360);
        flagX.x -= (moveY / screenHeight * 180);
        if ((flagX.x + 360) % 360 >= 80 && (flagX.x + 360) % 360 < 180)
            flagX.x = 80;
        if ((flagX.x + 360) % 360 <= 290 && (flagX.x + 360) % 360 > 180)
            flagX.x = 290;
        rotX.transform.eulerAngles = ClearVector3(flagX);
        rotY.transform.eulerAngles = ClearVector3(flagY);
        startScreenPos = Input.mousePosition;

    }


    /// <summary>
    /// 镜头景深
    /// </summary>
    public void MouseOfFieldOfView()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            mainCamera.fieldOfView -= fieldOfViewSpeed;
            if (mainCamera.fieldOfView <= fieldMin)
                mainCamera.fieldOfView = fieldMin;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            mainCamera.fieldOfView += fieldOfViewSpeed;
            if (mainCamera.fieldOfView >= fieldMax)
                mainCamera.fieldOfView = fieldMax;
        }

    }

    /// <summary>
    /// 清理Vector3 变量使其在0-360之间
    /// </summary>
    /// <param name="rot"></param>
    /// <returns></returns>
    public Vector3 ClearVector3(Vector3 rot)
    {
        rot.x = (rot.x + 360) % 360;
        rot.y = (rot.y + 360) % 360;
        rot.z = (rot.z + 360) % 360;

        return rot;
    }
}
