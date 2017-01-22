using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokyoSprite : MonoBehaviour {
    public Sprite JP;
    public Sprite EN;

	// Use this for initialization
	void Start () {
        if (Change_lang_Button.now_lang == "Japanese") {
            gameObject.GetComponent<Image>().sprite = JP;
        }else
        {
            gameObject.GetComponent<Image>().sprite = EN;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
