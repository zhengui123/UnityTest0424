using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CunChu : MonoBehaviour {


	void Start ()
    {
        PlayerPrefs.SetString("str01", "yyy");
        PlayerPrefs.SetInt("int01", 10);
	}
	
	void Update ()
    {
		
	}

    public void DeleteKey()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SetKey()
    {
        PlayerPrefs.SetString("str01", PlayerPrefs.GetString("str01", "00")+"1");
        PlayerPrefs.SetInt("int01", PlayerPrefs.GetInt("int01", 0)+1);
    }
    public void GetKey()
    {
        Debug.Log(PlayerPrefs.GetString("str01", "00"));
        Debug.Log(PlayerPrefs.GetInt("int01",0));
    }
}
