using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TestNavMesh : MonoBehaviour {

    public NavMeshAgent navMeshAgent;
    public Transform endPos;
	void Start ()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        endPos = GameObject.Find("Cube").transform;
        navMeshAgent.SetDestination(endPos.position);
      

    }

    void Update ()
    {
        if (Vector3.Distance(endPos.position, transform.position) <= 1.5f)
        {
            navMeshAgent.isStopped = true;
            Debug.Log(gameObject.name);
        }
	}
}
