using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : MonoBehaviour
{

    [Header("Menu Navigation")]
    [SerializeField] private UI mainMenu;

    [Header("Menu Buttons")]
    [SerializeField] private Button backButton;

    private SaveSlot[] saveSlots;
    private bool isLoadingGame = false;

    private void Awake()
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }
    public void onBackClicked()
    {
        this.DeactivateMenu();
    }
    public void OnSaveSlotClicked(SaveSlot saveSlot)
    {
        DataPersistenceManager.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
        if (!isLoadingGame)
        {
            DataPersistenceManager.instance.NewGame();
        }
        DataPersistenceManager.instance.SaveGame();
        Global.nxtLVL = 1;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void ActivateMenu(bool isLoadingGame)
    {
        this.gameObject.SetActive(true);
        this.isLoadingGame = isLoadingGame;
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfiesGameData();

        foreach(SaveSlot saveSlot in saveSlots)
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame)
            {
                saveSlot.SetInteractable(false);
            }
            else
            {
                saveSlot.SetInteractable(true);
            }
        }
    }
    public void DeactivateMenu()
    {
        this.gameObject.SetActive(false);
    }
    private void DisableMenuButtons()
    {
        foreach(SaveSlot saveSlot in saveSlots)
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}
