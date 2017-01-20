using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	private Animator myAnim;
	private bool isScroll;

	void Start () {
		myAnim = GetComponent<Animator>();
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (isScroll) {
				isScroll = false;
			} else {
				isScroll = true;
			}
		}

		myAnim.SetBool("Scroll", isScroll);
	}
}
