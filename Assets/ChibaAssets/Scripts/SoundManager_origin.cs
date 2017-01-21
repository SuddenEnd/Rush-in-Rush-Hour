using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public AudioSource SEroot;
    public List<AudioClip> SEList = new List<AudioClip>();

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

    public void SE_Shot(int i)
    {
        SEroot.PlayOneShot(SEList[i]);
    }
}

