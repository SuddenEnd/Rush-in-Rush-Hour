using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float vel=0.10f;
    public float right=5f;
    public float left= -5f;
    public static int stress_point = 0;
    public int add_stress_point = 10;
    
    //遷移したい任意のシーン名を入力する
    public string scene;

    public GameObject user;
    public float power=300f;
    bool Collision_now;
    Vector3 other_position;
    //車両移動待機中falseにする
    static public bool prepare;

    //千葉追加分
    private Vector3 autoPosition;
    private float speed;
    private float speed_debug;
    private GameObject m_camera;
    public bool backRotate;
    private bool isBugClear;
    private float bugClearTimer;
    // Use this for initialization
    void Start()
    {
        bugClearTimer = 0;
        backRotate = false;
        m_camera = GameObject.Find("Main Camera");
        speed = 0;
        prepare = true;
    }


    // Update is called once per frame
     void Update()
    {
//<<<<<<< HEAD
//        if (prepare == false) return;

//        Debug.Log(transform.position);
//=======

        if (bugClearTimer < 1 && !isBugClear)
        {
            transform.Translate(0, 0.000000000000000001f, 0);
            isBugClear = false;
            bugClearTimer += Time.deltaTime;
        }
        else if (bugClearTimer > 0 && isBugClear)
        {
            transform.Translate(0, -0.000000000000000001f, 0);
            isBugClear = true;
            bugClearTimer -= Time.deltaTime;
        }

        if (transform.eulerAngles.y > 270 || transform.eulerAngles.y < 90)
            backRotate = false;
        else
            backRotate = true;

        if (!prepare)
            PlayerAutoMove();
        else
        {
            autoPosition = transform.position;
            speed = 0;
            prepare = true;
        }

        if (prepare == false) return; 
//>>>>>>> origin/Shimo

        if (Input.GetKey(KeyCode.W))
        {
            if (backRotate && Mathf.Abs(Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, m_camera.transform.position.z))) < 4f) { }
            else
                transform.position += transform.forward * vel;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!backRotate && Mathf.Abs(Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, m_camera.transform.position.z))) < 4f) { }
            else
                transform.position -= transform.forward * vel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, right, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -right, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "NPC")
        {
            stress_point += add_stress_point;
            Debug.Log(stress_point);
//<<<<<<< HEAD

            if (stress_point > 100) SceneManager.LoadScene("Ending");

            if (stress_point > 100) SceneManager.LoadScene("Ending");
//>>>>>>> origin / Shimo

        }
    }

//<<<<<<< HEAD
//    private void OnCollisionStay(Collision other)
//    {

//        Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();

//        if (other.gameObject.tag == "NPC")
//        {
//            other_position = other.transform.position;
//            Collision_now = true;
//        }
//        if (Input.GetKey(KeyCode.J) )
//        {
//            Vector3 direction = other_position - transform.position;
//            rigidbody.AddForce(power* direction.normalized, ForceMode.Force);
//        }
//        else Collision_now = false;
//    } 
//=======
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Stage")
        {
            transform.parent = col.gameObject.transform.parent.parent;
        }

        Rigidbody rigidbody = col.gameObject.GetComponent<Rigidbody>();

        if (col.gameObject.tag == "NPC")
        {
            other_position = col.transform.position;
            Collision_now = true;
        }
        if (Input.GetKey(KeyCode.J))
        {
            Vector3 direction = other_position - transform.position;
            rigidbody.AddForce(power * direction.normalized, ForceMode.Force);
        }
        else Collision_now = false;
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DoorSwitch")
        {
            col.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("isOpen", true);
            prepare = false;
        }
    }

    void PlayerAutoMove()
    {
        speed += 2f;
        transform.position = Vector3.Lerp(autoPosition, new Vector3(0, autoPosition.y, autoPosition.z -18f), speed * Time.deltaTime);
    }
//>>>>>>> origin/Shimo
}