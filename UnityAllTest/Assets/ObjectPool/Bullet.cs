using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnEnable()
    {
        StartCoroutine(AutoRecycle());
    }

    IEnumerator AutoRecycle()
    {
        yield return new WaitForSeconds(1f);

        GameControl.objectPool.RecycleObj(gameObject);
    }
}
