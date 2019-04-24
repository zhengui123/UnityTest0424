using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EditorTest : MonoBehaviour
{


    [MenuItem("Tools/删除场景中没用的meshcollider")]
    static public void Remove()
    {
        GameObject[] objs = (GameObject[]) FindObjectsOfType(typeof(GameObject));
        foreach (GameObject thisObj in objs)
        {
            //foreach (Collider collider in FindObjectsOfType(typeof(Collider)))
            //{
            //    DestroyImmediate(collider);
            //}

            //if(thisObj.name.ToLower().Contains("Cube".ToLower()))
            if (thisObj.name.IndexOf("cube", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                thisObj.AddComponent<BoxCollider>();
            }
        }

        AssetDatabase.SaveAssets();
    }

    [MenuItem("Tools/同步所有场景到SceneSetting文件")]
    static void CheckSceneSetting()
    {
        List<string> dirs = new List<string>();
        GetDirs(Application.dataPath, ref dirs);
        Debug.Log(dirs.Count);

        EditorBuildSettingsScene[] newSettings = new EditorBuildSettingsScene[dirs.Count];
        for (int i = 0; i < newSettings.Length; i++)
        {
            newSettings[i] = new EditorBuildSettingsScene(dirs[i], true);
        }
        EditorBuildSettings.scenes = newSettings;
        AssetDatabase.SaveAssets();
    }
    private static void GetDirs(string dirPath, ref List<string> dirs)
    {
        foreach (string path in Directory.GetFiles(dirPath))
        {
            if (System.IO.Path.GetExtension(path) == ".unity")
            {
                Debug.Log(path.Substring(path.IndexOf("Assets")));
                dirs.Add(path.Substring(path.IndexOf("Assets\\")));
            }
        }
        if (Directory.GetDirectories(dirPath).Length > 0)
        {
            foreach (string path in Directory.GetDirectories(dirPath))
                GetDirs(path, ref dirs);
        }
    }


    [MenuItem("Assets/Check Prefab Use ?")]
    static void OnScearchForReferences()
    {
        Debug.Log(Selection.gameObjects.Length);
        if (Selection.gameObjects.Length != 1)
        {
           return;
        }

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                EditorSceneManager.OpenScene(scene.path);
                GameObject[] objs = (GameObject[])FindObjectsOfType(typeof(GameObject));
                foreach (GameObject thisObj in objs)
                {
                    if (PrefabUtility.GetPrefabType(thisObj) == PrefabType.PrefabInstance)
                    {
                        UnityEngine.Object objParent = PrefabUtility.GetPrefabParent(thisObj);
                        string path = AssetDatabase.GetAssetPath(objParent);
                        if (path == AssetDatabase.GetAssetPath(Selection.activeGameObject))
                        {
                            Debug.Log(scene.path + "   " + GetGameObjectPath(thisObj));
                        }
                    }
                }
            }
        }
    }

    public static string GetGameObjectPath(GameObject obj)
    {
        string path = "/"+ obj.name;
        while (obj.transform.parent)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name +path;
        }

        return path;
    }

}
