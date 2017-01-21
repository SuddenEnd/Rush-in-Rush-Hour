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

7    public GameObject user;
    public float power=300f;
    bool Collision_now;
    Vector3 other_position;
    //車両移動待機中falseにする
    static bool prepare=true;


    // Update is called once per frame
    void Update()
    {
        if (prepare == false) return;

        Debug.Log(transform.position);

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * vel;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * vel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, right, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
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

    private void OnCollisionStay(Collision other)
    {

        Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "NPC")
        {
            other_position = other.transform.position;
            Collision_now = true;
        }
        if (Input.GetKey(KeyCode.J) )
        {
            Vector3 direction = other_position - transform.position;
            rigidbody.AddForce(power* direction.normalized, ForceMode.Force);
        }
        else Collision_now = false;
    } 
}