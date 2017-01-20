using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "DoorSwitch") {
            col.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("isOpen", true);
        }
    }

    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Stage")
        {
            transform.parent = col.gameObject.transform.parent;
        }
    }

    void PlayerMove() {
        if (Input.GetKey(KeyCode.A)) {
            transform.position += new Vector3(-3 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(3 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 10 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -10 * Time.deltaTime);
        }
    }
}
