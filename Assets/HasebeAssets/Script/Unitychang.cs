﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychang : MonoBehaviour {
    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            //transform.position += transform.forward * 0.01f;
            animator.SetBool("is_running", true);
        }
        else
        {
            animator.SetBool("is_running", false);
        }
        if (Input.GetKey("d"))
        {
            //transform.Rotate(0, 10, 0);
        }
        if (Input.GetKey("a"))
        {
            //transform.Rotate(0, -10, 0);
        }
    }
}

