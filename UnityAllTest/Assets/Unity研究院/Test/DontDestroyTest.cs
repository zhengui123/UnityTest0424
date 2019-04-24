using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyTest : MonoBehaviour
{

    public GameObject obj;
	void Start ()
	{
		
	}
	
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.A))
	    {
	        if (SceneManager.GetActiveScene().name == "1")
	        {
	            DontDestroyOnLoad(gameObject);
	            DontDestroyOnLoad(obj);
                SceneManager.LoadScene("2");
            }
            else if(SceneManager.GetActiveScene().name == "2")
	        {
                SceneManager.LoadScene("1");
                Destroy(obj);
	            Destroy(gameObject);
            }

        }
	}
}
