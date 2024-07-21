using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Black_Screen_Fade : MonoBehaviour
{
    public float fade_speed = 1f;
    public bool fade_enabled;
    public GameObject player;
    public BaseForQuests bfq;

    public float x_p;
    public float y_p;
    public float z_p;

    public float X_R;
    public float Y_R;
    public float Z_R;

    private void Update()
    {
        if (fade_enabled)
            Fade();
        if (!fade_enabled)
            Fade2();
    }

    public void Fade()
    {
        StartCoroutine(Fade_In());
    }
    public void Fade2()
    {
        StartCoroutine(Fade_Out());
    }

    IEnumerator Fade_In()
    {
        Image fade_image = GetComponent<Image>();
        Color color = fade_image.color;

        while (color.a < 1f)
        {
            color.a += fade_speed * Time.deltaTime;
            fade_image.color = color;
            yield return null;
        }
        fade_enabled = false;
        player.transform.position = new Vector3(x_p, y_p, z_p);
        player.transform.eulerAngles = new Vector3(X_R, Y_R, Z_R);
    }

    IEnumerator Fade_Out()
    {
        Image fade_image = GetComponent<Image>();
        Color color = fade_image.color;

        while (color.a > 0f)
        {
            color.a -= fade_speed * Time.deltaTime;
            fade_image.color = color;
            yield return null;
        }
        fade_enabled = false;
    }
}
