using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {


    public Dictionary<string, List<GameObject>> pool;
    public Dictionary<string, GameObject> prefabs;

    #region 单例
    public static ObjectPool instance;

    private ObjectPool()
    {
        pool = new Dictionary<string, List<GameObject>>();
        prefabs = new Dictionary<string, GameObject>();
    }

    public static ObjectPool GetInstance()
    {
        if (instance == null)
        {
            instance = new ObjectPool();
        }
        return instance;
    }
    #endregion

    /// <summary>
    /// 从对象池中获取对象，对象池--
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    public GameObject GetObj(string objName)
    {

        GameObject result = null;
        //对象池有对象
        if (pool.ContainsKey(objName))
        {

            if (pool[objName].Count > 0)
            {
                result = pool[objName][0];
                result.SetActive(true);
                pool[objName].Remove(result);
                return result;
            }
        }

        //对象池中无对象
        GameObject prefab = null;
        //加载过预制体
        if (prefabs.ContainsKey(objName))
        {
            prefab = prefabs[objName];
        }
        //没加载过预制体
        else
        {
            prefab = Resources.Load<GameObject>("Prefabs/" + objName);
            prefabs.Add(objName, prefab);
        }

        result = GameObject.Instantiate(prefab);
        result.name = objName;
        return result;
    }

    /// <summary>
    /// 回收对象到对象池
    /// </summary>
    /// <param name="obj"></param>
    public void RecycleObj(GameObject obj)
    {
        obj.SetActive(false);

        if (pool.ContainsKey(obj.name))
        {
            pool[obj.name].Add(obj);
        }
        else
        {
            pool.Add(obj.name, new List<GameObject> { obj });
          
        }
    }
}
