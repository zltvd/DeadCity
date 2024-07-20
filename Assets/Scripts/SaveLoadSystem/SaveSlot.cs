using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.GlobalIllumination;
using Unity.VisualScripting;
using UnityEngine.UI;

public class SaveSlot : MonoBehaviour
{
    [Header("Profile")]
    [SerializeField] private string profileId = "";

    [Header("Content")]
    [SerializeField] private GameObject noDataContent;
    [SerializeField] private GameObject hasDataContent;
    [SerializeField] private TextMeshProUGUI numOfSave;
    [SerializeField] private TextMeshProUGUI dataOfSave;
    private Button saveSlotButton;
    private void Awake()
    {
        saveSlotButton = this.GetComponent<Button>();
    }
    public void SetData(GameData data)
    {
        if (data == null)
        {
            noDataContent.SetActive(true);
            hasDataContent.SetActive(false);
        }
        else
        {
            noDataContent.SetActive(false);
            hasDataContent.SetActive(true);
            dataOfSave.text = data.saveDate + " " + data.saveTime;
            numOfSave.text = "Сохранение " + this.profileId;
        }
    }
    public string GetProfileId()
    {
        return this.profileId;
    }
    public void SetInteractable(bool interactable)
    {
        saveSlotButton.interactable = interactable; 
    }
}
