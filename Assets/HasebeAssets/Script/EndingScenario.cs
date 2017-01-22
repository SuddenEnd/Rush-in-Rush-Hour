using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UnityEngine.SceneManagement;


public class EndingScenario : MonoBehaviour
{
    public AdvEngine engine;
    string scenarioLabel;
    //遷移したい任意のシーン名を入力する
    public string scene;

    // Use this for initialization
    void Start()
    {
        int resultStresspoint = Player_Controller.stress_point;

        //stress値によってエンディング変化
        if(Change_lang_Button.now_lang == "Japanese") {
            if (Player_Controller.isLeftGameOver) scenarioLabel = "GameOver_left";
            else if (TimeManager.TimeUpflag) scenarioLabel = "GameOver_timeup";
            else if (resultStresspoint >= 1000) scenarioLabel = "GameOver_stress";
            else if (resultStresspoint > 600) scenarioLabel = "Badend";
            else if (resultStresspoint > 400) scenarioLabel = "Nomalend";
            else scenarioLabel = "Goodend";
        }

        else
        {
            if (Player_Controller.isLeftGameOver) scenarioLabel = "GameOver_left_Eng";
            else if (TimeManager.TimeUpflag) scenarioLabel = "GameOver_timeup_Eng";
            else if (resultStresspoint >= 1000) scenarioLabel = "GameOver_stress_Eng";
            else if (resultStresspoint > 600) scenarioLabel = "Badend_Eng";
            else if (resultStresspoint > 400) scenarioLabel = "Nomalend_Eng";
            else scenarioLabel = "Goodend_Eng";
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
