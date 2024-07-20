using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip btn_click;
    public AudioClip shop_click;

    public void btnClick()
    {
        AudioSource.PlayOneShot(btn_click);
    }

    public void shopClick()
    {
        AudioSource.PlayOneShot(shop_click);
    }
}
