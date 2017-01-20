﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	private GameObject Mob;
	private Vector3 spawnPoint;

	void Start () {
		Mob = Resources.Load("Mob") as GameObject;
		spawnPoint = gameObject.transform.position;
		//Instantiate(Mob, gameObject.transform.position, Quaternion.identity);
		StartCoroutine("Spawn");
	}

	void Update () {
		//Instantiate(Mob, gameObject.transform.position, Quaternion.identity);

	}

	IEnumerator Spawn() {
		while (true) {
			Instantiate(Mob, spawnPoint, Quaternion.identity); 
			yield return new WaitForSeconds(1f);
		}

	}
}
