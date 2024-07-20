using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    public GameObject panelChest;
    public itemMenu menu;
    public Inventory inventory;
    public GameObject player;
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] public List<Image> borders = new List<Image>();
    [SerializeField] private List<TMP_Text> amounts = new List<TMP_Text>();
    public void UpdateUI()
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].color = new Color(1, 1, 1, 1);
            icons[i].sprite = inventory.GetItem(i).itemDecrs.icon;
            amounts[i].text = inventory.GetAmount(i) > 1 ? inventory.GetAmount(i).ToString() : "";
            if (inventory.items[i].equiped == true)
            {
                borders[i].gameObject.SetActive(true);
            }
            else
            {
                borders[i].gameObject.SetActive(false);
            }
        }
        for (int i = inventory.GetSize(); i < icons.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 0);
            icons[i].sprite = null;
            amounts[i].text = "";
            borders[i].gameObject.SetActive(false);
        }
    }
    public void showMenu(int i)
    {
        for (int y = 0; y < inventory.GetSize(); y++)
        {
            borders[y].gameObject.SetActive(false);
        }
        if (inventory.GetItem(i) != null)
        {
            menu.show(icons[i].transform, i);
            borders[i].gameObject.SetActive(true);
        }
    }
    public void showChestMenu()
    {
        panelChest.SetActive(true);
    }
    public void hideChestMenu()
    {
        panelChest.SetActive(false);
    }
}
