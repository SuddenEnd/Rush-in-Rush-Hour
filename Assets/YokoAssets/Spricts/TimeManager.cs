using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    SoundManager_origin SMO;


    [Header("ゲームタイム")]
    public float gameTime;
    [Header("到着予告時間")]
    public float anounceTime;
    [Header("ドアの空いている時間")]
    public float doorTime;
    [Header("走行時間")]
    public float runTimememory;
    [Header("停車時間")]
    public float stopTimememory;

    public bool Running = true;
    
    private float runTime;    
    private float stopTime;
    private bool flashcooltime = false;

    public static int flashcount = 0;


    public FlashManager FlashM;
    public Platform PlatF;
    TrainManager TrainM;
    NPCManager NPCM;
    GameObject[] Mobs;

	// Use this for initialization
	void Start () {
		SMO = GameObject.Find("SoundManager").GetComponent<SoundManager_origin>();
		//        FlashM = GameObject.Find("FlashIcon").GetComponent<FlashManager>();
		//        PlatF = GameObject.Find("Platform").GetComponent<Platform>();
		TrainM = GameObject.Find("TrainManager").GetComponent<TrainManager>();
        NPCM = GameObject.Find("NPCManager").GetComponent<NPCManager>();
     //   TrainSposi = TrainS.transform;
        PlatF.isScroll = true;
    }
	
	// Update is called once per frame
	void Update () {
        gameTime -= Time.deltaTime;
        Runningjudge();
        judgetime();
        if (runTimememory - runTime <= anounceTime)
        {
            Flashjudge();
            flashcooltime = true;
        }

	}

    void Runningjudge()
    {
        if(runTime >= runTimememory)
        {
            StartCoroutine("DoorOpen");
			SMO.SE_Shot(4);
		}

		if (stopTime >= stopTimememory)
        {
            StartCoroutine("DoorClose");
			SMO.SE_Shot(9);
            
		}
    }
    void judgetime()
    {
        if(Running == true)
        {
            runTime += Time.deltaTime;
        }

        if(Running == false)
        {
            stopTime += Time.deltaTime;
        }
    }
    void Flashjudge()
    {
        if(flashcooltime == false)
        {
            FlashM.Flashing(flashcount);
        }

    }

    private IEnumerator DoorOpen()
    {
        PlatF.isScroll = false;
        runTime = 0.0f;
        yield return new WaitForSeconds(2.5f);
        Running = false;
        TrainM.TrainDoorOpen();
        NPCM.GetOffNPC();
        yield return new WaitForSeconds(2.0f);
		Mobs = GameObject.FindGameObjectsWithTag("Mob");
		foreach (GameObject mob in Mobs) {
			mob.GetComponent<MobController>().RideTrain();
		}
        flashcooltime = false;
        
    }

    private IEnumerator DoorClose()
    {
        stopTime = 0.0f;
        yield return new WaitForSeconds(2.5f);
        Running = true;
        PlatF.isScroll = true;

    }
}
