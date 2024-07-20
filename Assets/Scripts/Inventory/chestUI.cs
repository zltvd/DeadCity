using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class chestUI : MonoBehaviour
{
    public CheastInventory inventory;
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private List<TMP_Text> amounts = new List<TMP_Text>();
    public void UpdateUI()
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].color = new Color(1, 1, 1, 1);
            icons[i].sprite = inventory.GetItem(i).itemDecrs.icon;
            amounts[i].text = inventory.GetAmount(i) > 1 ? inventory.GetAmount(i).ToString() : "";
        }
        for (int i = inventory.GetSize(); i < icons.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 0);
            icons[i].sprite = null;
            amounts[i].text = "";
        }
    }
}
