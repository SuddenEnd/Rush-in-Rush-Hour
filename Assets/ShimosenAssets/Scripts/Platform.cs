using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private GameObject mobObj;
	private Transform myTfm;
	private Animator myAnim;

	private bool isScroll;

	void Start () {
		mobObj = Resources.Load("Mob") as GameObject;
		myTfm = transform;
		myAnim = GetComponent<Animator>();

	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (isScroll) {
				isScroll = false;
			} else {
				//isScroll = true;
				Invoke("SpawnAtAlignment", 1.0f);

			}
		}

		myAnim.SetBool("Scroll", isScroll);
	}

	void SpawnAtAlignment() {
		GameObject[] aligns = GameObject.FindGameObjectsWithTag("Alignment");

		foreach (GameObject align in aligns) {
			GameObject mob = Instantiate(mobObj, align.transform.position, Quaternion.identity, myTfm);
			//Debug.Log(mob.transform.position);
			//mob.transform.SetParent(myTfm, true);
		}
	}
}
