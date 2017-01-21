using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class mainLoadScript : MonoBehaviour
{
    //遷移したい任意のシーン名を入力する
    public string scene;

    public void onClick()
    {
        GetComponent<Button>().onClick.AddListener(LoadMain);
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(scene);
    }

}