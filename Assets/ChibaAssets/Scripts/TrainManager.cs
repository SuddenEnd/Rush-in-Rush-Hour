using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {
    public List<GameObject> TrainList = new List<GameObject>();
    [Range(1, 10)]
    public int trainLength;

	// Use this for initialization
	void Start () {
        for (int i=0; i < trainLength; i++) {
            CreateTrain(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateTrain(int Distance) {
        int trainRandom = Random.Range (0, TrainList.Count);
        Instantiate(TrainList[trainRandom], new Vector3(0, 0, 50 * Distance), Quaternion.identity);
    }
}
