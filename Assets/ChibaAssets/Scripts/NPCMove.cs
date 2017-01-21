using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour {

    private Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        if (Mathf.Abs(Vector3.Distance(transform.position, GameObject.Find("Home01").transform.position)) < Mathf.Abs(Vector3.Distance(transform.position, GameObject.Find("Home02").transform.position)))
        {
            target = GameObject.Find("Home01").transform;
        }
        else {
            target = GameObject.Find("Home02").transform;
        }
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 10;
    }

    void Update()
    {
        agent.SetDestination(target.position);

        if (Mathf.Abs(Vector3.Distance(transform.position, target.transform.position)) < 2f) {
            Destroy(this.gameObject);
        }
    }
}
