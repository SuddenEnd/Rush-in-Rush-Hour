using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

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

    private bool Running = true;
    
    public float runTime;
    
    public float stopTime;
    private bool flashcooltime = false;


    public static int flashcount = 0;


    FlashManager FlashM;
    Platform PlatF;
    TrainManager TrainM;

	// Use this for initialization
	void Start () {
        FlashM = GameObject.Find("FlashIcon").GetComponent<FlashManager>();
        PlatF = GameObject.Find("Platform").GetComponent<Platform>();
        TrainM = GameObject.Find("Debug_TrainManager").GetComponent<TrainManager>();
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
        }

        if(stopTime >= stopTimememory)
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

    private IEnumerator DoorOpen()
    {
        PlatF.isScroll = false;
        runTime = 0.0f;
        yield return new WaitForSeconds(2.0f);
        Running = false;
        TrainM.TrainDoorOpen();
        flashcooltime = false;
        
    }

    private IEnumerator DoorClose()
    {
        stopTime = 0.0f;
        yield return new WaitForSeconds(2.0f);
        Running = true;
        PlatF.isScroll = true;
    }
}
