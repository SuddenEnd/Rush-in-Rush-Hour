using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public float vel=0.10f;
    public float right=5f;
    public float left= -5f;
    //乗客と接触すると上昇するストレス値
    public static int stress_point = 0;
    public int add_stress_point = 10;
    //遷移したい任意のシーン名を入力する
    public string scene;

    //車両移動待機中falseにする
    static public bool prepare;

    //千葉追加分
    private Vector3 autoPosition;

    public GageManager GageM;

    private GameObject m_camera;
    public bool backRotate;
    private bool isBugClear;
    private float bugClearTimer;

    static public bool isClear; 
    // Use this for initialization
    void Start()
    {
        stress_point = 0;
        bugClearTimer = 0;
        backRotate = false;
        m_camera = GameObject.Find("Main Camera");
        prepare = true;
        isClear = true;
    }

    // Update is called once per frame
     void Update()
    {
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

        if (prepare == false) return; 

        if (Input.GetKey(KeyCode.W))
        {
            if (backRotate && Mathf.Abs(Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, m_camera.transform.position.z))) < 4f) { }
            else
               transform.Translate(Vector3.forward * vel * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (!backRotate && Mathf.Abs(Vector3.Distance(new Vector3(0, 0, transform.position.z), new Vector3(0, 0, m_camera.transform.position.z))) < 4f) { }
            else
                transform.Translate(Vector3.forward * -vel * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, right, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -right, 0);
        }

        if (TimeManager.TimeUpflag) SceneManager.LoadScene("Ending");

    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "NPC" || other.gameObject.tag == "Mob")
        {
 //           GageM.StressUp();
            
 //           Debug.Log(stress_point);
            if(stress_point>2000) SceneManager.LoadScene("Ending");

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Stage")
        {
            transform.parent = col.gameObject.transform.parent.parent;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "DoorSwitch")
        {
            if (col.transform.parent.GetComponent<TrainStatus>().ID < GameObject.Find("TrainManager").GetComponent<TrainManager>().trainLength - 1)
            {
                col.gameObject.transform.parent.gameObject.GetComponent<Animator>().SetBool("isOpen", true);
                TrainManager.trainNum++;
                Destroy(col.gameObject);
            }
        }
        if (col.gameObject.tag == "Door")
        {
            if (10 > GameObject.Find("TrainManager").GetComponent<TrainManager>().trainCount) {
                GameObject.Find("TrainManager").GetComponent<TrainManager>().trainCount++;
            }
            if (col.transform.parent.GetComponent<TrainStatus>().ID < GameObject.Find("TrainManager").GetComponent<TrainManager>().trainLength - 1)
            {
                prepare = false;
            }
            else
            {
                SceneManager.LoadScene("Ending");
                isClear = true;
                Destroy(col.gameObject);
            }

            Destroy(col.gameObject);
        }

    }
}