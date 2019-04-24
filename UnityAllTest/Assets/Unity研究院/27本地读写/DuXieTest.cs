using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// android本地读写
/// </summary>
public class DuXieTest : MonoBehaviour
{
    public Text text;
    private ArrayList infoall;
	void Start ()
	{
        DeletFile(Application.persistentDataPath,"FileName.txt");
		CreateFile(Application.persistentDataPath, "FileName.txt", "test111");
	    CreateFile(Application.persistentDataPath, "FileName.txt", "test2222");

        infoall = LoadFile(Application.persistentDataPath, "FileName.txt");
	    foreach (string str in infoall)
	    {
	        text.text += str;
	        text.text += "  ";
            Debug.Log(str);
	    }
	}

    void CreateFile(string path, string name, string info)
    {
        StreamWriter sw;
        FileInfo t = new FileInfo(path +"//"+ name);
        if (!t.Exists)
            sw = t.CreateText();
        else
            sw = t.AppendText();
        sw.WriteLine(info);
        sw.Close();
        sw.Dispose();
    }

    ArrayList LoadFile(string path, string name)
    {
        StreamReader sr = null;
        try
        {
            sr = File.OpenText(path + "//" + name);
        }
        catch (Exception e)
        {
            return null;
        }

        string line;
        ArrayList arrlist = new ArrayList();

        while ((line = sr.ReadLine())!=null)
        {
            arrlist.Add(line);
        }
        sr.Close();
        sr.Dispose();
        return arrlist;
    }

    void DeletFile(string path, string name)
    {
        File.Delete(path + "//" + name);
    }
}
