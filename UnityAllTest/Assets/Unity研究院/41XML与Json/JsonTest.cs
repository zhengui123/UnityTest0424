using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using LitJson;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    void Start()
    {
        //ResolveJson();
        MergerJson();
    }

    // 解析json字符串显示字典键值
    public void ResolveJson()
    {
        string str = @"
            {
                ""Name""     : ""yusong"",
                ""Age""      : 26,
                ""Birthday"" : ""1986-11-21"",
 				""Thumbnail"":[
				{
           			""Url"":    ""http://xuanyusong.com"",
           			""Height"": 256,
           			""Width"":  ""200""
				},
				{
           			""Url"":    ""http://baidu.com"",
           			""Height"": 1024,
           			""Width"":  ""500""
				}
 
				]
            }";
        JsonData jd = JsonMapper.ToObject(str);

        Debug.Log("name = " + (string)jd["Name"]);
        Debug.Log("Age = " +(int)jd["Age"]);
        Debug.Log("Birthday = " + (string)jd["Birthday"]);
        JsonData jdItems = jd["Thumbnail"];

        for (int i = 0; i < jdItems.Count; i++)
        {
            Debug.Log("Url =" + jdItems[i]["Url"]);
            Debug.Log("Height =" + jdItems[i]["Height"]);
            Debug.Log("Width =" + jdItems[i]["Width"]);
        }
    }

    public void MergerJson()
    {
        StringBuilder sb = new StringBuilder();
        JsonWriter writer = new JsonWriter(sb);

        writer.WriteObjectStart();

        writer.WritePropertyName("Name");
        writer.Write("This");

        writer.WritePropertyName("Age");
        writer.Write(11);

        writer.WritePropertyName("Girl");
        writer.WriteArrayStart();

        writer.WriteObjectStart();
        writer.WritePropertyName("AA");
        writer.Write("11");
        writer.WritePropertyName("BB");
        writer.Write(10);
        writer.WriteObjectEnd();

        writer.WriteArrayEnd();
        
        writer.WriteObjectEnd();
        Debug.Log(sb.ToString());

        JsonData jd = JsonMapper.ToObject(sb.ToString());

        Debug.Log("name = " + (string)jd["Name"]);
        Debug.Log("Age = " + (int)jd["Age"]);
        //JsonData jdItems = jd["Girl"];
        //for (int i = 0; i < jdItems.Count; i++)
        //{
        //    Debug.Log("Girl name = " + jdItems[i]["name"]);
        //    Debug.Log("Girl age = " + (int)jdItems[i]["age"]);
        //}

        string str = Application.dataPath + @"/json111.json";
        FileInfo file = new FileInfo(str);
        // 判断有没有文件，有则打开文件，，没有创建后打开文件
        StreamWriter sw = file.CreateText();
        sw.WriteLine(sb.ToString());
        sw.Close();
        sw.Dispose();
        //AssetDatabase.Refresh();
    }
}
