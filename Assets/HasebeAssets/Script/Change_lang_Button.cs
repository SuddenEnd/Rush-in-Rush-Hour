using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change_lang_Button : MonoBehaviour
{
    static public string now_lang = "Japanese";

    //public void onClick()
    //{
    //    GetComponent<Button>().onClick.AddListener(change_lang);
    //}
    public void change_lang()
    {
        if (now_lang == "Japanese") now_lang = "English";
        else if (now_lang == "English") now_lang = "Japanese";

        Debug.Log(now_lang);
    }
}
