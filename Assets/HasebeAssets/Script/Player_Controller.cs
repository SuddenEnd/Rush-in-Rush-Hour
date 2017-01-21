using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float vel=0.10f;
    public float right=5f;
    public float left= -5f;
    public static int stress_point;
    public int add_stress_point = 10;
    //遷移したい任意のシーン名を入力する
    public string scene;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * vel;
        }
        if (Input.GetKey("d"))
        {
            transform.Rotate(0, right, 0);
        }
        if (Input.GetKey("a"))
        {
            Debug.Log(left);
            transform.Rotate(0, left, 0);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "NPC")
        {
            stress_point += add_stress_point;
            Debug.Log(stress_point);
            if(stress_point>100) SceneManager.LoadScene("Ending");

        }
    }
}