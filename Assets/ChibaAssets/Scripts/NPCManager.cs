﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {
    GameObject[] tagObjs;
    private GameObject Player;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.O)) {
            GetOffNPC();
        }
    }

    public void GetOffNPC()
    {
        tagObjs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject obj in tagObjs)
        {
            if (obj.transform.parent == Player.transform.parent) {
                int GetOffRandom = Random.Range(0, 3);
                if (GetOffRandom != 2)
                {
                    obj.GetComponent<NPCMove>().enabled = true;
                }
            }
        }
    }
}
