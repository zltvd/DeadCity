using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    [SerializeField] private TMP_Text promtText;
    [SerializeField] private GameObject UIPanel;
    public bool IsDisplayed = false;
    void Start()
    {
        UIPanel.SetActive(false);
    }
    public void SetUp(string PromtText)
    {
        promtText.text = PromtText;
        UIPanel.SetActive(true);
        IsDisplayed = true;
    }
    public void Close()
    {
        IsDisplayed = false;
        UIPanel.SetActive(false);
    }
}
