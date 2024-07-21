using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPS_Counter : MonoBehaviour
{
    public float updateInterval = 0.5f;
    float accum = 0.0f;
    int frames = 0;
    float timeleft;
    float fps;
    public TMP_Text fps_text;

    GUIStyle textStyle = new GUIStyle();

    void Start()
    {
        timeleft = updateInterval;

        //textStyle.fontStyle = FontStyle.Bold;
        //textStyle.normal.textColor = Color.white;
    }

    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            fps = (accum / frames);
            timeleft = updateInterval;
            accum = 0.0f;
            frames = 0;
        }
    }

    void OnGUI()
    {
        fps_text.text = fps.ToString("F2");
        //GUI.Label(new Rect(5, 5, 100, 25), fps.ToString("F2") + "FPS", textStyle);
    }
}
