using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainManager : MonoBehaviour {
    public List<GameObject> TrainList = new List<GameObject>();
    [Range(0, 10)]
    public int trainLength;
    public List<Animator> animatorList = new List<Animator>();
    private bool isClose;
    [Range(1, 10)]
    public float doorLimit;
    private float doorLimit_memory;
    public GameObject trainSet;
    public int trainCount;
    private int trainCount_memory;
    public Text whatTrainNumber;
    static public int trainNum;

    // Use this for initialization
    void Start () {
        trainNum = 1;
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
        if (Change_lang_Button.now_lang == "Japanese")
        {
            whatTrainNumber.text = "" + (trainNum) + "両目";
        }
        else
        {
            whatTrainNumber.text = "Car No." + (trainNum);
        }
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
                isClose = true;
                GameObject.Find("SoundManager").GetComponent<SoundManager_origin>().SE_Shot(1);
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
            if (animatorList[i] != null)
                animatorList[i].SetBool("isOpen", true);
        }
    }

    void TrainDoorClose()
    {
        isClose = true;
        for (int i = 0; i < animatorList.Count; i++)
        {
            if (animatorList[i] != null)
                animatorList[i].SetBool("isOpen", false);
        }
    }
}
