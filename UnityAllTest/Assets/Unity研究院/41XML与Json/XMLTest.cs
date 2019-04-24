using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XMLTest : MonoBehaviour {


	void Start () {
        //CreateXML();
        //UpdateXml();
        // AddXML();
        DeleteXml();
    }
	
	void Update () {
		
	}

    /// <summary>
    /// 创建xml
    /// </summary>
    public void CreateXML()
    {
        string filepath = Application.dataPath + @"/my.xml";
        if(!File.Exists(filepath))
        { 
            //创建XML文档实例
            XmlDocument xmlDoc = new XmlDocument();
            //创建root结点，也就是最上一层结点
            XmlElement root = xmlDoc.CreateElement("transforms");
            //继续创建下一层结点
            XmlElement elmNew = xmlDoc.CreateElement("rotation");
            elmNew.SetAttribute("id", "0");
            elmNew.SetAttribute("name", "test");
            XmlElement rotation_X = xmlDoc.CreateElement("x");
            rotation_X.InnerText = "0";
            XmlElement rotation_Y = xmlDoc.CreateElement("y");
            rotation_Y.InnerText = "1";
            XmlElement rotation_Z = xmlDoc.CreateElement("z");
            rotation_Z.InnerText = "2";
            rotation_Z.SetAttribute("id", "1");

            elmNew.AppendChild(rotation_X);
            elmNew.AppendChild(rotation_Y);
            elmNew.AppendChild(rotation_Z);

            root.AppendChild(elmNew);
            xmlDoc.AppendChild(root);

            xmlDoc.Save(filepath);
            Debug.Log("createXml OK!");
        }
    }

    /// <summary>
    /// 更新xml
    /// </summary>
    public void UpdateXml()
    {
        string filePath = Application.dataPath + @"/my.xml";
        if (File.Exists(filePath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            // 根据路径将xml读取出来
            xmlDoc.Load(filePath);
            //得到transforms下所有子节点
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;

            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("id") == "0")
                {
                    xe.SetAttribute("id", "1000");

                    foreach (XmlElement x1 in xe.ChildNodes)
                    {
                        if (x1.Name == "z")
                        {
                            //这里是修改节点名称对应的数值，而上面的拿到节点连带的属性。。。
                            x1.InnerText = "update00000";
                        }

                    }
                    break;
                }
            }
            xmlDoc.Save(filePath);
            Debug.Log("UpdateXml OK!");
        }
    }


    /// <summary>
    /// 添加xml
    /// </summary>
    public void AddXML()
    {
        string filepath = Application.dataPath + @"/my.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNode root = xmlDoc.SelectSingleNode("transforms");
            XmlElement elmNew = xmlDoc.CreateElement("rotation");
            elmNew.SetAttribute("id", "1");
            elmNew.SetAttribute("name", "new1");
            XmlElement rotX = xmlDoc.CreateElement("x");
            rotX.InnerText = "0";
            XmlElement rotY = xmlDoc.CreateElement("y");
            rotY.InnerText = "1";
            XmlElement rotZ = xmlDoc.CreateElement("z");
            rotZ.InnerText = "2";
            elmNew.AppendChild(rotX);
            elmNew.AppendChild(rotY);
            elmNew.AppendChild(rotZ);
            root.AppendChild(elmNew);
            xmlDoc.AppendChild(root);
            xmlDoc.Save(filepath);
            Debug.Log("AddXml OK!");
        }
    }
    /// <summary>
    /// 删除xml
    /// </summary>
    public void DeleteXml()
    {
        string filepath = Application.dataPath + @"/my.xml";

        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("id") == "1")
                {
                    xe.RemoveAttribute("name");
                }
                foreach (XmlElement x1 in xe)
                {
                    if (x1.Name == "z")
                    {
                        x1.RemoveAll();
                    }
                }
            }
            xmlDoc.Save(filepath);
            Debug.Log("DeletXml Ok!");
        }
    }

    /// <summary>
    /// 解析与输出上面的xml
    /// </summary>
    public void ShowXml()
    {
        string filepath = Application.dataPath + @"/my.xml";
        if (File.Exists(filepath))
        {


        }
    }
}
