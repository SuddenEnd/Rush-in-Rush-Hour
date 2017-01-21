using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Explain_btn : MonoBehaviour {

    //遷移したい任意のシーン名を入力する
    public string scene;
 //   string now_lang = now_lang;
    Button btn;

    public void Update()
    {
        if (Change_lang_Button.now_lang == "English")
        {
            btn = GetComponent<Button>();
            GetComponentInChildren<Text>().text = "EXPLANATION";
        }
        if (Change_lang_Button.now_lang == "Japanese")
        {
            btn = GetComponent<Button>();
            GetComponentInChildren<Text>().text = "説明";
        }
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(scene);
    }

}

