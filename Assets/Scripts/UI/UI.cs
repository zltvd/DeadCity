using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public SaveSlot saveSlot;
    public GameObject saveMenu;
    public GameObject bgLoad;
    public GameObject bgStart;
    public GameObject aboutPanel;
    [Header("Menu Navigation")]
    [SerializeField] private SaveSlotsMenu saveSlotsMenu;
    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            //loadGameButon.interactable = false;
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            aboutPanel.SetActive(false);
            saveMenu.SetActive(false);
        }
    }
    public void lvlSelect(int next)
    {
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);

    }
    public void OnNewGameClicked(int next)
    {
        saveSlotsMenu.ActivateMenu(false);
        aboutPanel.SetActive(false);
        bgLoad.SetActive(false);
        bgStart.SetActive(true);
    }
    public void OnLoadGameClicked(int next)
    {
        saveSlotsMenu.ActivateMenu(true);
        aboutPanel.SetActive(false);
        bgLoad.SetActive(true);
        bgStart.SetActive(false);
    }
    public void OnContinueGameClicked(int next)
    {
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void ActivateMenu()
    {
        saveMenu.SetActive(true);
    }
    public void DeactivateMenu()
    {
        saveMenu.SetActive(false);
    }
    public void aboutPanelActive()
    {
        if (aboutPanel.activeInHierarchy == true)
        {
            aboutPanel.SetActive(false);
        }
        else
        {
            aboutPanel.SetActive(true);
            saveMenu.SetActive(false);
        }
    }
}
