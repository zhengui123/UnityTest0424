using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DL_Test : MonoBehaviour {

    void OnEnable()
    {
        Log.daili1 += DoOnething;
        Log.daili2 += DoTwothing;

    }

    void OnDisable()
    {
        Log.daili1 -= DoOnething;
        Log.daili2 -= DoTwothing;
    }

    public void DoOnething(string str)
    {
        Debug.Log("DoOnething " + str);
    }

    public void DoTwothing(string str)
    {
        Debug.Log("DoTwothing " + str);
    }

}
