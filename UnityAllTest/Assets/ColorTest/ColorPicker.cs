using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorPicker : MonoBehaviour
{

    // 方便在 Inspect 观察自己选的颜色变化

    public Color CurrentColor;

    // Update is called once per frame

    void Update()
    {

        // 按下鼠标右键开启颜色获取协程

        if (Input.GetMouseButtonDown(0))
        {

            StartCoroutine(CaptureScreenshot());

        }

    }
    public Image image;
    public Texture2D m_texture;
    IEnumerator CaptureScreenshot()

    {

        //只在每一帧渲染完成后才读取屏幕信息

        yield return new WaitForEndOfFrame();

        m_texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        // 读取Rect范围内的像素并存入纹理中

        m_texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        // 实际应用纹理

        m_texture.Apply();

        Color color = m_texture.GetPixel((int)Input.mousePosition.x, (int)Input.mousePosition.y);

        CurrentColor = color;
        image.color = color;
        // 停止该协程

        StopCoroutine(CaptureScreenshot());

    }

}