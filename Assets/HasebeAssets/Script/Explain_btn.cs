using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Explain_btn : MonoBehaviour {

    //遷移したい任意のシーン名を入力する
    public string scene;
    Image btn;
    public Sprite japanese, english;

    public void Update()
    {
        btn = GetComponent<Image>();

        //言語に応じてjapanese,englishに入った画像を表示
        if (Change_lang_Button.now_lang == "Japanese")
        {
            btn.sprite = japanese;
        }
        else btn.sprite = english;
    }

    public void LoadMain()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager_origin>().SE_Shot(10);
        SceneManager.LoadScene(scene);
    }

}

