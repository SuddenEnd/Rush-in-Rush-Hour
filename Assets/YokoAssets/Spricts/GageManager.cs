using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour {

    Player_Controller PC;
    public Sprite stressgage;
    float Stressmeter;

    // Use this for initialization
    void Start () {
        this.transform.FindChild("Stressgage").gameObject.GetComponent<Image>().sprite = stressgage;
        this.transform.FindChild("Stressgage").gameObject.GetComponent<Image>().fillAmount = Stressmeter;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Player_Controller.stress_point += /*PC.add_stress_point*/1;
            StressUp();
        }
	}

    public void StressUp()
    {
        Stressmeter = Player_Controller.stress_point / 100.0f;
        this.transform.FindChild("Stressgage").gameObject.GetComponent<Image>().fillAmount = Stressmeter;
    }
}
