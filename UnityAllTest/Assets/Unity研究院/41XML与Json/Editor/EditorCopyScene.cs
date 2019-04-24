using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using LitJson;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>
/// 场景内所有物体均需要设为预制体
/// https://www.xuanyusong.com/archives/1919
/// </summary>
public class EditorCopyScene : EditorWindow
{

    [MenuItem("Window/MyEditor/CopySceneToXmlAndJson")]
    static void ShowWindow()
    {
        EditorCopyScene window =
            (EditorCopyScene) EditorWindow.GetWindow(typeof(EditorCopyScene), false, "复制场景到xml和json");
        window.Show();
    }

    void OnGUI()
    {
        if (GUILayout.Button("复制场景到Xml"))
        {
            CopySceneToXml();
        }

        if (GUILayout.Button("复制场景到Json"))
        {
            ExportJSON();
        }
    }

    //复制场景到XMl
    static void CopySceneToXml()
    {
        string filePath = Application.dataPath + @"/StreamingAssets/myScenes.xml";
        Debug.Log(File.Exists(filePath));
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        XmlDocument xmlDoc = new XmlDocument();
        XmlElement root = xmlDoc.CreateElement("GameObjects");

        foreach (UnityEditor.EditorBuildSettingsScene thisScene in UnityEditor.EditorBuildSettings.scenes)
        {
            if (thisScene.enabled)
            {
                string name = thisScene.path;
                EditorSceneManager.OpenScene(name);
                XmlElement scenes = xmlDoc.CreateElement("scenes");
                scenes.SetAttribute("name", name);

                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                {
                    XmlElement gameObject = xmlDoc.CreateElement("gameObjects");
                    gameObject.SetAttribute("name", obj.name);

                    gameObject.SetAttribute("asset", obj.name + ".prefab");
                    XmlElement transform = xmlDoc.CreateElement("transform");
                    XmlElement position = xmlDoc.CreateElement("position");
                    XmlElement position_x = xmlDoc.CreateElement("x");
                    position_x.InnerText = obj.transform.position.x + "";
                    XmlElement position_y = xmlDoc.CreateElement("y");
                    position_y.InnerText = obj.transform.position.y + "";
                    XmlElement position_z = xmlDoc.CreateElement("z");
                    position_z.InnerText = obj.transform.position.z + "";
                    position.AppendChild(position_x);
                    position.AppendChild(position_y);
                    position.AppendChild(position_z);

                    XmlElement rotation = xmlDoc.CreateElement("rotation");
                    XmlElement rotation_x = xmlDoc.CreateElement("x");
                    rotation_x.InnerText = obj.transform.rotation.eulerAngles.x + "";
                    XmlElement rotation_y = xmlDoc.CreateElement("y");
                    rotation_y.InnerText = obj.transform.rotation.eulerAngles.y + "";
                    XmlElement rotation_z = xmlDoc.CreateElement("z");
                    rotation_z.InnerText = obj.transform.rotation.eulerAngles.z + "";
                    rotation.AppendChild(rotation_x);
                    rotation.AppendChild(rotation_y);
                    rotation.AppendChild(rotation_z);

                    XmlElement scale = xmlDoc.CreateElement("scale");
                    XmlElement scale_x = xmlDoc.CreateElement("x");
                    scale_x.InnerText = obj.transform.localScale.x + "";
                    XmlElement scale_y = xmlDoc.CreateElement("y");
                    scale_y.InnerText = obj.transform.localScale.y + "";
                    XmlElement scale_z = xmlDoc.CreateElement("z");
                    scale_z.InnerText = obj.transform.localScale.z + "";

                    scale.AppendChild(scale_x);
                    scale.AppendChild(scale_y);
                    scale.AppendChild(scale_z);

                    transform.AppendChild(position);
                    transform.AppendChild(rotation);
                    transform.AppendChild(scale);

                    gameObject.AppendChild(transform);
                    scenes.AppendChild(gameObject);
                    root.AppendChild(scenes);
                    xmlDoc.AppendChild(root);
                    xmlDoc.Save(filePath);

                }

            }
        }
        AssetDatabase.Refresh();
    }

    //复制场景到Json
    static void ExportJSON()
    {
        string filepath = Application.dataPath + @"/StreamingAssets/json.txt";
        FileInfo t = new FileInfo(filepath);
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        StreamWriter sw = t.CreateText();

        StringBuilder sb = new StringBuilder();
        JsonWriter writer = new JsonWriter(sb);
        writer.WriteObjectStart();
        writer.WritePropertyName("GameObjects");
        writer.WriteArrayStart();

        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            if (S.enabled)
            {
                string name = S.path;
                EditorSceneManager.OpenScene(name);
                writer.WriteObjectStart();
                writer.WritePropertyName("scenes");
                writer.WriteArrayStart();
                writer.WriteObjectStart();
                writer.WritePropertyName("name");
                writer.Write(name);
                writer.WritePropertyName("gameObject");
                writer.WriteArrayStart();

                foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
                {
                    if (obj.transform.parent == null)
                    {
                        writer.WriteObjectStart();
                        writer.WritePropertyName("name");
                        writer.Write(obj.name);

                        writer.WritePropertyName("position");
                        writer.WriteArrayStart();
                        writer.WriteObjectStart();
                        writer.WritePropertyName("x");
                        writer.Write(obj.transform.position.x.ToString("F5"));
                        writer.WritePropertyName("y");
                        writer.Write(obj.transform.position.y.ToString("F5"));
                        writer.WritePropertyName("z");
                        writer.Write(obj.transform.position.z.ToString("F5"));
                        writer.WriteObjectEnd();
                        writer.WriteArrayEnd();

                        writer.WritePropertyName("rotation");
                        writer.WriteArrayStart();
                        writer.WriteObjectStart();
                        writer.WritePropertyName("x");
                        writer.Write(obj.transform.rotation.eulerAngles.x.ToString("F5"));
                        writer.WritePropertyName("y");
                        writer.Write(obj.transform.rotation.eulerAngles.y.ToString("F5"));
                        writer.WritePropertyName("z");
                        writer.Write(obj.transform.rotation.eulerAngles.z.ToString("F5"));
                        writer.WriteObjectEnd();
                        writer.WriteArrayEnd();

                        writer.WritePropertyName("scale");
                        writer.WriteArrayStart();
                        writer.WriteObjectStart();
                        writer.WritePropertyName("x");
                        writer.Write(obj.transform.localScale.x.ToString("F5"));
                        writer.WritePropertyName("y");
                        writer.Write(obj.transform.localScale.y.ToString("F5"));
                        writer.WritePropertyName("z");
                        writer.Write(obj.transform.localScale.z.ToString("F5"));
                        writer.WriteObjectEnd();
                        writer.WriteArrayEnd();

                        writer.WriteObjectEnd();
                    }
                }

                writer.WriteArrayEnd();
                writer.WriteObjectEnd();
                writer.WriteArrayEnd();
                writer.WriteObjectEnd();
            }
        }
        writer.WriteArrayEnd();
        writer.WriteObjectEnd();

        sw.WriteLine(sb.ToString());
        sw.Close();
        sw.Dispose();
        AssetDatabase.Refresh();
    }
}

