using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Change_lang_Button : MonoBehaviour
{
    static public string now_lang = "Japanese";
    string language;

    private void Start()
    {
        language = this.name;
    }

    public void change_lang()
    {
        now_lang = language;

        SceneManager.LoadScene("Start");
    }
}
