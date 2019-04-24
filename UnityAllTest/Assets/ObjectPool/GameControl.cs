using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public GameObject plane;
    public GameObject wallPrefab;

    public Vector2 offset = new Vector2();
    public float speed = 30f;
    public int row = 6;
    private RaycastHit hit;

    public static ObjectPool objectPool;
	void Start ()
    {
        objectPool = ObjectPool.GetInstance();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < row; j++)
            {
                GameObject.Instantiate(wallPrefab, new Vector3(i, j, 0) + new Vector3(offset.x, offset.y, 0), Quaternion.identity).transform.parent = plane.transform;
            }
        }
	}

    Vector3 rayVec;
	void Update ()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                rayVec = hit.point - Camera.main.transform.position;

                GameObject bullet = objectPool.GetObj("bullet");
                bullet.transform.position = Camera.main.transform.position;
                bullet.GetComponent<Rigidbody>().velocity = rayVec.normalized * speed;
            }

        }
       
	}
}
