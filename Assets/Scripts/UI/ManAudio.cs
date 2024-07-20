using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManAudio : MonoBehaviour
{
    public static ManAudio instance;
    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
