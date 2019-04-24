using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test0329 : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (obj.CompareTag("111"))
        {
            Debug.Log("111");
        }	
	}
}
