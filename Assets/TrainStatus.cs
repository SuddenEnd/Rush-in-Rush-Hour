using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainStatus : MonoBehaviour {
    public int ID;
    private float destroyLag;
    private float lifeTimer;
	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        lifeTimer += Time.deltaTime;
        if (lifeTimer < 1 && ID > 2) {
            transform.position = new Vector3(0, 0, 13.6f * 2);
        }
        if (GameObject.Find("TrainManager").GetComponent<TrainManager>().trainCount - 7 >= ID) {
            destroyLag += Time.deltaTime;
            if(destroyLag > 0.1f)
               Destroy(this.gameObject);
        }
    }
}
