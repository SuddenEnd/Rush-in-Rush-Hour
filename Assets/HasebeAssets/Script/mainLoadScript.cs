﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class mainLoadScript : MonoBehaviour
{
    //遷移したい任意のシーン名を入力する
    public string scene;
    string now_lang = Change_lang_Button.now_lang;
    Button btn;

    //public void Update()
    //{
    //    if (now_lang == "Japanese")
    //    {
    //        btn = GetComponent<Button>();
    //        GetComponentInChildren<Text>().text = "START";
    //    }
    //}

    public void LoadMain()
    {
        SceneManager.LoadScene(scene);
    }

}