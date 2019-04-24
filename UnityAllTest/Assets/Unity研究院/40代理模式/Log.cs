using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : MonoBehaviour
{

    public delegate void DaiLi1(string str);

    public static event DaiLi1 daili1;

    public delegate void DaiLi2(string str);

    public static event DaiLi2 daili2;
    
    void Start()
    {
        if (daili1 != null)
        {
            daili1("daili1");
        }

        if (daili2 != null)
        {
            daili2("2222222222222");
        }

    }

    public void Test1(string str)
    {
        Debug.Log(str);
    }
}

