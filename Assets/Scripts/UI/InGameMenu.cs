using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.Rendering.PostProcessing;

public class InGameMenu : MonoBehaviour
{
    public GG mew;
    public PostProcessVolume Blur;
    public Animator animator;
    private void Start()
    {
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
    }
    public void Resume(GameObject menu)
    {
        Time.timeScale = 1.0f;
        menu.SetActive(false);
        mew.panelTarhet.SetActive(true);
        Blur.enabled = false;
        animator.SetBool("isClose", true);
        mew.bfq.invToHide.SetActive(true);
    }
    public void Save(GameObject menu)
    {
        DataPersistenceManager.instance.SaveGame();
        Resume(menu);
    }
    public void loadLastSave()
    {
        Global.nxtLVL = 1;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void MainMenu(int next)
    {
        //DataPersistenceManager.instance.SaveGame();
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Menu(int next)
    {
        //DataPersistenceManager.instance.SaveGame();
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Settings()
    {
        mew.panel.SetActive(false);
        mew.settingsPanel.SetActive(true);
    }
    public void Exit()
    {
        //DataPersistenceManager.instance.SaveGame();
        UnityEngine.Application.Quit();
        Time.timeScale = 1.0f;
    }
    
}
