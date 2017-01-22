using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    static public bool Running;
    
    public float runTime;    
    public float stopTime;
    private bool flashcooltime = false;

    public static int flashcount = 0;
    public static bool TimeUpflag = false;


    public FlashManager FlashM;
    public Platform PlatF;
    TrainManager TrainM;
    NPCManager NPCM;
    GameObject[] Mobs;

	// Use this for initialization
	void Start () {
        Running = true;
        flashcooltime = false;
        flashcount = 0;
        TimeUpflag = false;
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

    public void GameTimeUp()
    {
        StartCoroutine("Onerest");
    }

    private IEnumerator DoorOpen()
    {
        PlatF.isScroll = false;
        runTime = 0.0f;
        yield return new WaitForSeconds(2.5f);
        stopTime = 0;
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
        runTime = 0.0f;
        Running = true;
        PlatF.isScroll = true;
    }

    private IEnumerator Onerest()
    {
        yield return new WaitForSeconds(4.0f);
        TimeUpflag = true;
        SceneManager.LoadScene("Ending");
    }
}
