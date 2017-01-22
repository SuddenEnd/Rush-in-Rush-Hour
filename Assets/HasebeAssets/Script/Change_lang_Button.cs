using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change_lang_Button : MonoBehaviour
{
    //言語選択以降の言語判定に使用する
    //宴使用シーン(テキストボックス使用時）)は宴自体がユーザーの使用言語を
    //判定するため無関係
    static public string now_lang = "Japanese";
    string language;

    private void Start()
    {
        //押したボタンのオブジェクト名を使用
        language = this.name;
    }

    public void change_lang()
    {
        now_lang = language;
        //Startシーンに遷移
        SceneManager.LoadScene("Start");
    }
}
