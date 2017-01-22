using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UnityEngine.SceneManagement;


public class EndingScenario : MonoBehaviour
{
    SoundManager_origin SMO;
    public AdvEngine engine;
    string scenarioLabel;
    //遷移したい任意のシーン名を入力する
    public string scene;
    public GameObject clear;
    public GameObject over;
    private bool isClear;

    // Use this for initialization
    void Start()
    {
        SMO = GameObject.Find("SoundManager").GetComponent<SoundManager_origin>();
        int resultStresspoint = Player_Controller.stress_point;

        //stress値によってエンディング変化
        if(Change_lang_Button.now_lang == "Japanese") {
            if (Player_Controller.isLeftGameOver) { scenarioLabel = "GameOver_timeup"; SMO.SE_Shot(3); }
            else if (TimeManager.TimeUpflag) { scenarioLabel = "GameOver_timeup"; SMO.SE_Shot(3); }
            else if (resultStresspoint >= 4500) { scenarioLabel = "GameOver_stress"; SMO.SE_Shot(3); }
            else if (resultStresspoint > 2700) { scenarioLabel = "Badend"; SMO.SE_Shot(3); isClear = true; }
            else if (resultStresspoint > 1800) { scenarioLabel = "Nomalend"; SMO.SE_Shot(2); isClear = true; }
            else { scenarioLabel = "Goodend"; SMO.SE_Shot(2); isClear = true; }
        }

        else
        {
            if (Player_Controller.isLeftGameOver) { scenarioLabel = "GameOver_timeup_Eng"; SMO.SE_Shot(3); }
            else if (TimeManager.TimeUpflag) { scenarioLabel = "GameOver_timeup_Eng"; SMO.SE_Shot(3); }
            else if (resultStresspoint >= 4500) { scenarioLabel = "GameOver_stress_Eng"; SMO.SE_Shot(3); }
            else if (resultStresspoint > 2700) { scenarioLabel = "Badend_Eng"; SMO.SE_Shot(3); isClear = true; }
            else if (resultStresspoint > 1800) { scenarioLabel = "Nomalend_Eng"; SMO.SE_Shot(2); isClear = true; }
            else { scenarioLabel = "Goodend_Eng"; SMO.SE_Shot(2); isClear = true; }
        }

        StartCoroutine(CoTalk());
    }

    IEnumerator CoTalk()
    {
        //「宴」のシナリオ呼び出し
        engine.JumpScenario(scenarioLabel);

        //「宴」のシナリオ終了待ち
        while (!engine.IsEndScenario)
        {
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
