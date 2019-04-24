using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EditorGetSceneA : EditorWindow
{
    [MenuItem("Window/AddSceneA")]
    static void AddSceneA()
    {
        EditorGetSceneA window = (EditorGetSceneA) EditorWindow.GetWindow(typeof(EditorGetSceneA));
        window.Show();
    }

    private Scene scene;
    private int startNum;
    private int endNum;
    private string firstPath;
    private int flagNum;
    private bool toggleEnabled;
    bool isShow;

    void OnGUI()
    {

        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("复制当前场景");
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        scene = SceneManager.GetActiveScene();
        GUILayout.Label(scene.path);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("复制从");
        startNum = int.Parse(EditorGUILayout.TextField(startNum.ToString()));
        GUILayout.Label("到");
        endNum = int.Parse(EditorGUILayout.TextField(endNum.ToString()));
        EditorGUILayout.EndHorizontal();

        flagNum = scene.path.IndexOf("Level ");
        if(flagNum >=0)
            firstPath = scene.path.Substring(0, flagNum);
        //Debug.Log(firstPath);
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("复制"))
        {
            Copy();
        }
        EditorGUILayout.EndHorizontal();

        toggleEnabled = EditorGUILayout.BeginToggleGroup("optional settings", toggleEnabled);
        if (toggleEnabled)
        {
            GUILayout.Label("thisshow");

        }
        EditorGUILayout.EndToggleGroup();

        isShow = GUILayout.Toggle(isShow, "111");
        if (isShow)
        {
            GUILayout.Label("thisshow111");

        }
        EditorGUILayout.EndVertical(); ;
    }


    private string nowPath;
    void Copy()
    {
        for (int i = startNum; i <= endNum; i++)
        {
            AssetDatabase.CreateFolder("Assets", i.ToString());
            //nowPath = firstPath + "/Level " + i;
            AssetDatabase.CreateFolder("Levels", "Level " + i);
            AssetDatabase.CopyAsset(scene.path,nowPath + "/copy" + i +".unity");
        }
    }
}
