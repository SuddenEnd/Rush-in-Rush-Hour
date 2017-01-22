using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utage;
using UnityEngine.SceneManagement;


public class StartScenario : MonoBehaviour {

    public AdvEngine engine;
    public string scenarioLabel;

    //遷移したい任意のシーン名を入力する
    public string scene;

    // Use this for initialization
    void Start () {
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
        //スタート画面に戻る
        SceneManager.LoadScene(scene);
    }

}
