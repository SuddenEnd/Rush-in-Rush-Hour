using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SoundManager_origin : MonoBehaviour
{
    public AudioSource SEroot;
    public List<AudioClip> SEList = new List<AudioClip>();
    public AudioClip BGM;
    bool isBgm;

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("SoundManager");
        if (obj.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Update()
    {
        if (Application.loadedLevelName == "Prologue")
        {
            SEroot.Stop();
            isBgm = false;
        }
        if (Application.loadedLevelName == "Start" && !isBgm) { 
            SEroot.PlayOneShot(BGM, 1);
            isBgm = true;
        }
    }

    public void SE_Shot(int i)
    {
        SEroot.PlayOneShot(SEList[i]);
    }
}

