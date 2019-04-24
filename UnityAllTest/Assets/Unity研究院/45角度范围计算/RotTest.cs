using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotTest : MonoBehaviour {

	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 80, 0));
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            transform.eulerAngles = new Vector3(0, 80, 0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.Rotate(new Vector3(0, 80, 0));
        }
	}
}
