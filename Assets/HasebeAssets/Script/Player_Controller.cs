using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float vel=0.10f;
    public float right=5f;
    public float left=5f;
    public int stress_point;
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
            transform.Rotate(0, left, 0);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "NPC")
        {
            stress_point++;
            Debug.Log(stress_point);
        }
    }
}