using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobController : MonoBehaviour {

	private GameObject[] targets;
	private GameObject target;
	private Transform myTfm;
	//private int rnd;
	private bool isRide;

	private UnityEngine.AI.NavMeshAgent agent;

	void Start() {
		myTfm = transform;
		targets = GameObject.FindGameObjectsWithTag("Target");

		float sqrDist = 99.9f;

		foreach (GameObject target in targets) {
			if (((myTfm.position - target.transform.position).sqrMagnitude) < sqrDist) {
				this.target = target;
				sqrDist = (myTfm.position - target.transform.position).sqrMagnitude;
			}
		}

		//rnd = Random.Range(0, targets.Length);

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//agent.enabled = false;
		//agent.Stop();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.O)) {
			isRide = true;
			agent.enabled = true;
			myTfm.SetParent(null);

		}


		if (isRide) {
			agent.SetDestination(target.transform.position);
		}
	}

	void OnCollisionEnter(Collision col) {

		//Debug.Log(col.gameObject.tag);

		if (col.gameObject.CompareTag("Target")) {
			//Destroy(gameObject);
		}

		if (col.gameObject.CompareTag("Finish")) {
			Debug.Log(col.gameObject.tag);
		}

	}

}
