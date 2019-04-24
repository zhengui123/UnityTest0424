using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BJQTest01 : MonoBehaviour {

    public bool isGood = false;

    [Tooltip("hp")]//鼠标hover的时候显示一个tooltip
    public int life = 0;

    [Range(0f, 1f)]//float slider
    public float CloudRange = 0.5f;

    [Range(0, 15)]//int slider
    public int CloudRangeInt = 1;

    [Header("OtherAttr")]//可以将属性隔离开，形成分组的感觉
    public float CloudHeader = 1f;

    [Space(30)]//可以与上面形成一个空隙
    public float CloudSpace = 1f;

    [HideInInspector]//使属性在inspector中隐藏，但是还是可序列化，想赋值可以通过写程序赋值序列化
    public float CloudHideInInspector = 1f;

    [NonSerialized]//使public属性不能序列化
    public float CloudNonSerialized = 1f;

    [SerializeField]//使private属性可以被序列化，在面板上显示并且可以读取保存
    private bool CloudSerializeField = true;


    // Use this for initialization
    [ContextMenu("CloudRangeInt = 10")]
    public void Test01()
    {
        CloudRangeInt = 10;
        Debug.Log("CloudRangeInt = 10 ....");
        life = UnityEngine.Random.Range(1, 100);
    }

    [MenuItem("CONTEXT/Transform/TestRandomPosition")]
    static void TestRandomPosition()
    {
        Debug.Log("TestRandomPosition");
        Transform[] transforms = Selection.transforms;
        foreach (Transform thisTransform in transforms)
        {
            Debug.Log(thisTransform.name);
        }
    }

    [MenuItem(@"Selction/CreateChild1")]

    public static void CreatChild()
    {
        //GetTransforms（）方法是Selection类提供的静态方法，其使用更加灵活，获取选中的对象
        Transform[] transforms = Selection.transforms;
       // Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.ExcludePrefab);

        for (int i = 0; i < transforms.Length; i++)
        {
            //创建一个球体
            GameObject gb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //设置其如对象为选中的Cube
            gb.transform.SetParent(transforms[i]);
            gb.name = "SphereChild";
            gb.transform.localPosition = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
    [MenuItem(@"Selction/CreateChild2")]

    public static void CreatChild2()
    {
        //GetTransforms（）方法是Selection类提供的静态方法，其使用更加灵活，获取选中的对象
        //Transform[] transforms = Selection.transforms;
         Transform[] transforms = Selection.GetTransforms(SelectionMode.TopLevel | SelectionMode.ExcludePrefab);

        for (int i = 0; i < transforms.Length; i++)
        {
            //创建一个球体
            GameObject gb = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            //设置其如对象为选中的Cube
            gb.transform.SetParent(transforms[i]);
            gb.name = "SphereChild";
            gb.transform.localPosition = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    const string Menu_Checked = "Cloud/MenuChecked";//checked menu的名字
    const string Key_MenuChecked = "MenuChecked";//checked menu状态存储的key

    [MenuItem(Menu_Checked)]
    static void MenuChecked()
    {
        bool flag = Menu.GetChecked(Menu_Checked);
        if (flag)
        {
            Debug.Log("Key_MenuChecked to 0");
            PlayerPrefs.SetInt(Key_MenuChecked, 0);//通过存储0和1来判断是否check menu
        }
        else
        {
            Debug.Log("Key_MenuChecked to 1");
            PlayerPrefs.SetInt(Key_MenuChecked, 1);
        }
        Menu.SetChecked(Menu_Checked, true);
    }

    [MenuItem(Menu_Checked, true)]//判断menu是否check的函数
    public static bool IsMenuChecked()
    {
        Menu.SetChecked(Menu_Checked, PlayerPrefs.GetInt(Key_MenuChecked, 0) == 1);
        return true;
    }
}
