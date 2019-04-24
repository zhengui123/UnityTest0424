using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YiBuJiaZai : MonoBehaviour
{
    private AsyncOperation asyn;
	void Start ()
	{
	    StartCoroutine(LoadScene());
	}
	
	void Update ()
	{
		
	}

    IEnumerator LoadScene()
    {
        asyn = SceneManager.LoadSceneAsync("2");
        Debug.Log((float)asyn.priority*100);
        yield return asyn;
    }
}
