using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private GameObject[] aligns;
	private List<GameObject> sortedAligns = new List<GameObject>();
	private GameObject mobObj;
	private Transform myTfm;
	private Animator myAnim;
	private bool isScroll;
	private int mobNum;

	// 乗り込む人数（最大40）
	private int MobNum {
		get {
			return this.mobNum;
		}
		set {
			this.mobNum = Mathf.Clamp(value, 0, 40);
		}
	}

	void Start () {
		MobNum = 10;

		mobObj = Resources.Load("Mob") as GameObject;
		myTfm = transform;
		myAnim = GetComponent<Animator>();

		aligns = GameObject.FindGameObjectsWithTag("Alignment");

		for (int num = 1; num <= 5; num++) {
			foreach (GameObject align in aligns) {
				int i = int.Parse(align.name.Substring(9));
				if (i == num) {
					sortedAligns.Add(align);
				}
			}
		}
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (isScroll) {
				isScroll = false;
			} else {
				isScroll = true;
				Invoke("SpawnAtAlignment", 1.0f);

			}
		}

		myAnim.SetBool("Scroll", isScroll);
	}

	void SpawnAtAlignment() {

		int count = 0;
		foreach (GameObject align in sortedAligns) {
			GameObject mob = Instantiate(mobObj, align.transform.position, Quaternion.identity, myTfm);
			count++;

			if (count >= mobNum) {
				break;
			}
		}
	}
}
