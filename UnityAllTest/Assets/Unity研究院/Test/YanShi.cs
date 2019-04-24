using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YanShi : MonoBehaviour
{


	void Start ()
	{
		Invoke("ShowWord", 3f);
	    StartCoroutine(YanChi());
	}
	
	void Update ()
	{
	    //RaycastHit hit;
	    //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
	    //{
     //       Debug.Log(hit.transform.name);
	    //}
	}

    public void ShowWord()
    {
        Debug.Log("Invoke延迟3秒");
    }

    IEnumerator YanChi()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("协程延迟3秒");

    }
}
