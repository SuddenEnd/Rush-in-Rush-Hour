using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GageManager : MonoBehaviour {

    Player_Controller PC;
    public Sprite stressgage;
    float Stressmeter;
    public float Stressmemory;

    // Use this for initialization
    void Start () {
        
        this.transform.FindChild("Stressgage").gameObject.GetComponent<Image>().sprite = stressgage;
        this.transform.FindChild("Stressgage").gameObject.GetComponent<Image>().fillAmount = Stressmeter;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void StressUp()
    {
        Player_Controller.stress_point += /*PC.add_stress_point*/1;
        Stressmeter = Player_Controller.stress_point / 5000.0f;
        this.transform.FindChild("Stressgage").gameObject.GetComponent<Image>().fillAmount = Stressmeter;
    }
}
