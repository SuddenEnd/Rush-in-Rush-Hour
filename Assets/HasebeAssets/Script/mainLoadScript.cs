﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class mainLoadScript : MonoBehaviour
{
    SoundManager_origin SMO;
    //遷移したい任意のシーン名を入力する
    public string scene;
    string now_lang = Change_lang_Button.now_lang;
    Button btn;

<<<<<<< HEAD
    //public void Update()
    //{
    //    if (now_lang == "Japanese")
    //    {
    //        btn = GetComponent<Button>();
    //        GetComponentInChildren<Text>().text = "START";
    //    }
    //}
=======


>>>>>>> origin/Haseve
    private void Start()
    {
        SMO = GameObject.Find("SoundManager").GetComponent<SoundManager_origin>();
    }

<<<<<<< HEAD
    public void Update()
    {
        if (now_lang == "Japanese")
        {
            btn = GetComponent<Button>();
            GetComponentInChildren<Text>().text = "START";
        }
    }


=======
>>>>>>> origin/Haseve
    public void LoadMain()
    {
        SMO.SE_Shot(10);
        SceneManager.LoadScene(scene);
    }

}