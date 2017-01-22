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
        if (TimeManager.TimeUpflag) scenarioLabel= "GameOver_timeup";
        else if (resultStresspoint >= 100) scenarioLabel = "GameOver_stress";
        else if (resultStresspoint > 60) scenarioLabel = "Badend";
        else if (resultStresspoint > 40) scenarioLabel = "Nomalend";
        else scenarioLabel = "Goodend";
        
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
