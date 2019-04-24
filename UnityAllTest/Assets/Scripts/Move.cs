using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    private float _speed;
    void Start ()
    {

        _speed = Time.deltaTime * 10;
        
	}

	// Update is called once per frame
	void Update ()
    {
        //transform.Rotate(speed, 0, 0);
        //transform.Rotate(Vector3.up * speed,Space.Self);
        //transform.Translate(0, speed, 0);
        //transform.Translate(speed*Vector3.up,Camera.main.transform);
    }
}
