using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void menuStart()
    {
        SceneManager.LoadScene(1);
    }
    public void menuExit()
    {
        Application.Quit();
    }
}
