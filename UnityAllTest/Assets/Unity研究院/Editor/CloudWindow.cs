using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CloudWindow))]
public class CloudWindow : EditorWindow
{

    #region 对话框
    //通过MenuItem按钮来创建这样的一个对话框  
    [MenuItem("Cloud/ShowEditorTestPanel")]
    public static void ConfigDialog()
    {
        EditorWindow.GetWindow(typeof(CloudWindow));
    }

    public UnityEngine.Object go = null;
    string goName = "default";
    float life = 100f;
    bool isAlive = true;
    bool toggleEnabled;
    void OnGUI()
    {
        //Label  
        GUILayout.Label("Label Test", EditorStyles.boldLabel);
        //通过EditorGUILayout.ObjectField可以接受Object类型的参数进行相关操作  
        go = EditorGUILayout.ObjectField(go, typeof(UnityEngine.Object), true);
        //Button  
        if (GUILayout.Button("Button Test"))
        {
            if (go == null)
            {
                Debug.Log("go == null");
            }
            else
            {
                Debug.Log(go.name);
            }
        }
        goName = EditorGUILayout.TextField("textfield", goName);

        toggleEnabled = EditorGUILayout.BeginToggleGroup("optional settings", toggleEnabled);
        if (toggleEnabled)
        {
            isAlive = EditorGUILayout.Toggle("isalive", isAlive);
            life = EditorGUILayout.Slider("life", life, 0, 100);
        }
        EditorGUILayout.EndToggleGroup();
    }


    #endregion

}
