using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {
    public List<GameObject> TrainList = new List<GameObject>();
    [Range(1, 10)]
    public int trainLength;
    private List<Animator> animatorList = new List<Animator>();
    private bool isClose;
    [Range(1, 10)]
    public float doorLimit;
    private float doorLimit_memory;
    public GameObject trainSet;

    // Use this for initialization
    void Start () {
        isClose = true;
        for (int i=0; i < trainLength; i++) {
            CreateTrain(i);
        }
        doorLimit_memory = doorLimit;
        trainSet = GameObject.Find("TrainSet");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O))
            TrainDoorOpen();
        if (!isClose) {
            if(doorLimit > 0)
                doorLimit -= Time.deltaTime;
            else
            {
                doorLimit = doorLimit_memory;
                TrainDoorClose();
            }
        }
	}

    void CreateTrain(int Distance) {
        int trainRandom = Random.Range (0, TrainList.Count);
        GameObject trainObject = Instantiate(TrainList[trainRandom]) as GameObject;
        trainObject.transform.position = new Vector3(0, 0, 13.6f * Distance);
        animatorList.Add(trainObject.transform.FindChild("DoorSet").GetComponent<Animator>());
        trainObject.transform.parent = trainSet.transform;
    }

    public void TrainDoorOpen() {
        isClose = false;
        for (int i=0; i < animatorList.Count; i++) {
            animatorList[i].SetTrigger("Open");
        }
    }

    void TrainDoorClose()
    {
        isClose = true;
        for (int i = 0; i < animatorList.Count; i++)
        {
            animatorList[i].SetTrigger("Close");
        }
    }
}
