using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour {

    private Transform target;
    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("Home").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 10;
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
