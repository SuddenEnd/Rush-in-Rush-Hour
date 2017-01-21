using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour {

	private GameObject[] targets;
	private Transform myTfm;
	private int rnd;
	private bool isRide;

	private UnityEngine.AI.NavMeshAgent agent;

	void Start() {
		myTfm = transform;
		targets = GameObject.FindGameObjectsWithTag("Target");
		rnd = Random.Range(0, targets.Length);

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//agent.enabled = false;
		//agent.Stop();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.S)) {
			isRide = true;
			agent.enabled = true;
			myTfm.SetParent(null);

		}


		if (isRide) {
			agent.SetDestination(targets[rnd].transform.position);
		}
	}

	void OnCollisionEnter(Collision col) {

		//Debug.Log(col.gameObject.tag);

		if (col.gameObject.CompareTag("Target")) {
			Destroy(gameObject);
		}

	}

}
