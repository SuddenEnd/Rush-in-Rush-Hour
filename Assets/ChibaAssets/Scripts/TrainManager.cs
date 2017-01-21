using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainManager : MonoBehaviour {
    public List<GameObject> TrainList = new List<GameObject>();
    [Range(0, 10)]
    public int trainLength;
    private List<Animator> animatorList = new List<Animator>();
    private bool isClose;
    [Range(1, 10)]
    public float doorLimit;
    private float doorLimit_memory;
    public GameObject trainSet;
    public int trainCount;
    private int trainCount_memory;

    // Use this for initialization
    void Start () {
        isClose = true;
        for (int i=0; i < trainCount; i++) {
            CreateTrain(i);
        }
        doorLimit_memory = doorLimit;
        trainSet = GameObject.Find("TrainSet");
        trainCount_memory = trainCount;
    }

    // Update is called once per frame
    void Update () {
        if (trainCount != trainCount_memory) {
            CreateTrain(trainCount - 1);
        }

        trainCount_memory = trainCount;

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

    public void CreateTrain(int Distance) {
        int trainRandom = Random.Range (0, TrainList.Count);
        GameObject trainObject = Instantiate(TrainList[trainRandom]) as GameObject;
        animatorList.Add(trainObject.transform.FindChild("DoorSet").GetComponent<Animator>());
        trainObject.transform.parent = trainSet.transform;
        trainObject.transform.position = new Vector3(0, 0, 13.6f * Distance);
        trainObject.GetComponent<TrainStatus>().ID = Distance;
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
