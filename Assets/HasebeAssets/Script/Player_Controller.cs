using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float vel, right, left;
    public int stress_point;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            transform.position += transform.forward * vel;
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, right, 0);
        }
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, left, 0);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy")
        {
            stress_point++;
            Debug.Log(stress_point);
        }
    }
}