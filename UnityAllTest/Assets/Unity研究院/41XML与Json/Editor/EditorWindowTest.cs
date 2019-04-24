using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using UnityEngine;
using UnityEditor;

public class EditorWindowTest : EditorWindow 
{
    private static EditorWindowTest window;
    [MenuItem("Window/MyEditor/EditorWindowTest")]
    static void ShowWindow()
    {
        window = (EditorWindowTest) EditorWindow.GetWindow(typeof(EditorWindowTest),false, "EditorWindowTest");
        window.Show();
    }

    private string move;
    private Texture img;
    private Texture oldImg;
    private Rect windowRect = new Rect(0, 0, 200, 200);
    string notificationStr = "我是消息内容";
    public void OnGUI()
    {
        //窗口最大化
        maximized = EditorGUILayout.ToggleLeft("Max", maximized);

        //设置窗口图标
        GUILayout.Label("放置图标", EditorStyles.boldLabel);
        img = (Texture)EditorGUILayout.ObjectField(img, typeof(UnityEngine.Object), true);
        if(img!=null)
            titleContent = new GUIContent(img);
        oldImg = img;

        wantsMouseMove = EditorGUILayout.ToggleLeft("响应鼠标移动", wantsMouseMove);
        //EditorGUILayout.LabelField("Mouse Position:", Input.mousePosition.ToString());
        EditorGUILayout.LabelField("Mouse Position:", Event.current.mousePosition.ToString());
        if (Event.current.type == EventType.mouseMove && wantsMouseMove)
        {
            Repaint();
        }

        //创建子窗口
        //BeginWindows();
        //windowRect = GUILayout.Window(1, windowRect, DoWindow, "子窗口");
        //EndWindows();

        //关闭窗口
        if (GUILayout.Button("关闭窗口"))
        {
            window.Close();
        }

        //显示消息
        notificationStr = EditorGUILayout.TextField(notificationStr);
        if (GUILayout.Button("显示消息"))
        {
            window.ShowNotification(new GUIContent(notificationStr));
        }
        if (GUILayout.Button("不显示消息"))
        {
            window.RemoveNotification();
        }

        //这段代码就是如果聚焦的窗口是Hierarchy窗口的话，那么就传递粘贴事件给Hierarchy窗口。
        //if (EditorWindow.focusedWindow.ToString().Trim() == "(UnityEditor.SceneHierarchyWindow)")
        //{
        //    EditorWindow.focusedWindow.SendEvent(EditorGUIUtility.CommandEvent("Paste"));//传递粘贴的事件
        //}
    }

    //Hierarchy视窗改变的时候，会执行这个方法的逻辑,
    //在Scene视图拖拽坐标不会被监听
    void OnHierarchyChange()
    {
        Debug.Log("Hierarchy变更");
    }

    //是Project视窗发生改变的时候，会执行该方法。
    void OnProjectChange()
    {
        Debug.Log("Project变更");
    }

    //这个方法是当你选择的物件发生变化（包括Scene，Project和Hierarchy视窗）的时候会执行该方法。
    void OnSelectionChange()
    {
        Debug.Log("Selection变更");
    }

    public void Update()
    {
        if (img != oldImg)
        {
            Debug.Log(1);
            Repaint();
        }
    }

    void DoWindow(int unusedWindowID)
    {
        GUILayout.Button("按钮");
        

        GUI.DragWindow();
    }

}
