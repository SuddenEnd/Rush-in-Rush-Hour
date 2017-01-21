using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private bool isFirst;
    private Vector3 cameraPosition;
    private float speed;
	// Use this for initialization
	void Start () {
        isFirst = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Player.passingDoor)
        {
            speed += 3f;
            if (!isFirst)
            {
                cameraPosition = this.transform.position;
                isFirst = true;
            }
            this.transform.position = Vector3.Lerp(cameraPosition, new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 13.6f), speed * Time.deltaTime);
        }

        if (Mathf.Abs(Vector3.Distance(this.transform.position, new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 13.6f))) < 0.5f && Player.passingDoor) {
            this.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z + 13.6f);
            Player.passingDoor = false;
            isFirst = false;
            speed = 0;
        }
    }
}
