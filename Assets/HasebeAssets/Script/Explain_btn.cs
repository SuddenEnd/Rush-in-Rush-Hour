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

        if (Change_lang_Button.now_lang == "Japanese")
        {
            btn.sprite = japanese;
        }
        else btn.sprite = english;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(scene);
    }

}

