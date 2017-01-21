using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    static public bool passingDoor;
    private Vector3 autoPosition;
    private float speed;
    private float speed_debug;
    private GameObject m_camera;
	// Use this for initialization
	void Start () {
        m_camera = GameObject.Find("Main Camera");
        speed = 0;
        passingDoor = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(Mathf.Abs(Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, m_camera.transform.position.z))));
        if (passingDoor)
            PlayerAutoMove();
        else
        {
            PlayerMove();
            autoPosition = transform.position;
            speed = 0;
        }
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "DoorSwitch") {
            col.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("isOpen", true);
            passingDoor = true;
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
        if (Input.GetKey(KeyCode.S) && Mathf.Abs(Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, m_camera.transform.position.z))) > 4f)
        {
            transform.position += new Vector3(0, 0, -10 * Time.deltaTime);
        }
    }

    void PlayerAutoMove() {
        speed += 2f;
        transform.position = Vector3.Lerp(autoPosition, new Vector3(0, autoPosition.y, autoPosition.z + 2), speed * Time.deltaTime);
    }
}
