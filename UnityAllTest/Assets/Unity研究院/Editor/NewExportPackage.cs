using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/// <summary>
/// 干净的导出资源到unitypackage包
/// </summary>
public class NewExportPackage : MonoBehaviour {

    [MenuItem("Assets/new Export Assets")]
    static void Build()
    {
        if (Selection.objects == null)
            return;
        List<string> paths = new List<string>();
        foreach (Object o in Selection.objects)
        {
            paths.Add(AssetDatabase.GetAssetPath(o));
        }

        AssetDatabase.ExportPackage(paths.ToArray(), "Assets/UnityPackage" + Selection.objects[0].name +".unitypackage",ExportPackageOptions.IncludeDependencies);
        AssetDatabase.Refresh();
        Debug.Log("build all done!");

    }
}
