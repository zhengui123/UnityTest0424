using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeLight : MonoBehaviour {

    public GameObject[] cube;
    public Material white;
    public Material pingk;
    public GameObject succesObj;

    private bool isSucces = false;
    [SerializeField]
    private bool[] isLight;


	void Start ()
    {
        succesObj.SetActive(false);
        isLight = new bool[cube.Length];
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                for(int i = 0; i < cube.Length; i++)
                {
                    if (hit.transform.name == cube[i].name)
                    {
                        isLight[GetNum(i - 1)] = !isLight[GetNum(i - 1)];
                        isLight[GetNum(i)] = !isLight[GetNum(i)];
                        isLight[GetNum(i+ 1)] = !isLight[GetNum(i + 1)];
                    }
                }

                isSucces = true;

                for (int i = 0; i < isLight.Length; i++)
                {
                    if (isLight[i])
                    {
                        cube[i].GetComponent<MeshRenderer>().material = pingk;
                    }
                    else
                    {
                        cube[i].GetComponent<MeshRenderer>().material = white;
                        isSucces = false;

                    }
                }
                Debug.Log(isSucces);

            }
        }
        if (isSucces)

        {
            succesObj.SetActive(true);
        }
    }


    int GetNum(int i)
    {
        
        return (i + cube.Length) % cube.Length;
    }
}
