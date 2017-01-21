using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class mainLoadScript : MonoBehaviour
{
    SoundManager_origin SMO;
    //遷移したい任意のシーン名を入力する
    public string scene;
<<<<<<< HEAD
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
=======
    Image btn;
    public Sprite japanese, english;


>>>>>>> origin/Haseve
    private void Start()
    {
        SMO = GameObject.Find("SoundManager").GetComponent<SoundManager_origin>();
    }

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
        SMO.SE_Shot(10);
        SceneManager.LoadScene(scene);
    }

}