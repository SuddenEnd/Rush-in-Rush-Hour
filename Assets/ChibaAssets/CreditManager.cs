using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditManager : MonoBehaviour {
    private float timer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > 55f && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene("Start");

        }

    }


}
