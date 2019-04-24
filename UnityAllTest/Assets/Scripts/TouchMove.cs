using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour {

	void Start ()
    {
		
	}

    private float startTouchPos;
    private float oldTouchPos;

    void Update ()
    {
       
        if (Input.touchCount == 1)
        {
            Debug.Log(1);
            if (Input.touches[0].phase == TouchPhase.Moved)
            {

            }
        }
        if (Input.touchCount == 2)

        {
            Debug.Log(2);
        }
    }
    public void OnTriggerStay(Collider other)
    {
        
    }
    public void OnTriggerExit(Collider other)
    {
        
    }

  
}
