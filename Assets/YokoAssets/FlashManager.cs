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
    private GameObject SignalIcon;
    private Image Signal;
    

    // Use this for initialization
    void Start()
    {
        Flashing(0);
    }

    // Update is called once per frame
    void Update()
    {
       
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
