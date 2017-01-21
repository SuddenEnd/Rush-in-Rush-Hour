using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashManager : MonoBehaviour {

    [Header("点滅ON")]
    public Sprite SignalOn;
    [Header("点滅OFF")]
    public Sprite SignalOff;
    [Header("点滅する秒数")]
    public float Flashtime;
    private Image Signal;
    

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Flashing(2);
        }
    }

    void Flashing(int Flashnumber)
    {
        if(Flashnumber == 0)
        {
            Signal = GameObject.Find("FlashIcon").GetComponent<Image>();
        }
        else
        {
            Signal = GameObject.Find("FlashIcon (" + Flashnumber + ")").GetComponent<Image>();
        }
        StartCoroutine("Flash");
    }

    private IEnumerator Flash()
    {
        //画像切り替え方式
        yield return new WaitForSeconds(Flashtime);
        Signal.sprite = SignalOn;
        yield return new WaitForSeconds(Flashtime);
        Signal.sprite = SignalOff;
        yield return new WaitForSeconds(Flashtime);
        Signal.sprite = SignalOn;
        yield return new WaitForSeconds(Flashtime);
        Signal.sprite = SignalOff;         
    }
}
