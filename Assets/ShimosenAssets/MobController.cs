using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour {

	private Transform target;

	private UnityEngine.AI.NavMeshAgent agent;

	void Start() {
		target = GameObject.FindWithTag("Target").transform;
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}


	void Update() {

		agent.SetDestination(target.position);
	
	}

	void OnCollisionEnter(Collision col) {

		//Debug.Log(col.gameObject.tag);

		if (col.gameObject.CompareTag("Death")) {
			Destroy(gameObject);
		}

	}

}
