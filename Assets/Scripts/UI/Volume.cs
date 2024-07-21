using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider sliderMusic;
    public string wichGroup;
    private void Start()
    {
        float volume = sliderMusic.value;
        mixer.SetFloat(wichGroup, Mathf.Log10(volume) * 20);
    }
    public void SetMusicVolume()
    {
        float volume = sliderMusic.value;
        mixer.SetFloat(wichGroup, Mathf.Log10(volume) * 20);
    }
}
