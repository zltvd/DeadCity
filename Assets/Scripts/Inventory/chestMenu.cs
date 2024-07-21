using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class chestMenu : MonoBehaviour
{
    public GG player;
    public void show(Transform parent)
    {
        transform.SetParent(parent, false);
        gameObject.SetActive(true);
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
}
