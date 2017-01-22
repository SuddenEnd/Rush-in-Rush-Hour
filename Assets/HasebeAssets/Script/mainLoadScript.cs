using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class mainLoadScript : MonoBehaviour
{
    SoundManager_origin SMO;
    //遷移したい任意のシーン名を入力する
    public string scene;
    Image btn;
    public Sprite japanese, english;


    private void Start()
    {
        SMO = GameObject.Find("SoundManager").GetComponent<SoundManager_origin>();
    }

    public void Update()
    {
        btn = GetComponent<Image>();
        //now_langに応じて使用するボタン画像を変化
        if (Change_lang_Button.now_lang == "Japanese")
        {
            btn.sprite = japanese;
        }
        else btn.sprite = english;
    }


    public void LoadMain()
    {
        SMO.SE_Shot(10);
        SceneManager.LoadScene(scene);
    }

}