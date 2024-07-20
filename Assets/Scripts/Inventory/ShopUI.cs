using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    public ShopInventory inventory;
    [SerializeField] private List<Image> icons = new List<Image>();
    [SerializeField] private List<TMP_Text> amounts = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> coast = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> descr = new List<TMP_Text>();
    public GameObject shop;
    public GameObject upgrade;
    public void UpdateUI()
    {
        for (int i = 0; i < inventory.GetSize(); i++)
        {
            icons[i].color = new Color(1, 1, 1, 1);
            icons[i].sprite = inventory.GetItem(i).itemDecrs.icon;
            amounts[i].text = inventory.GetAmount(i) > 1 ? inventory.GetAmount(i).ToString() : "";
            coast[i].text = ((inventory.GetItem(i).itemDecrs.itemCoast) * (inventory.GetItem(i).amount)).ToString();
            descr[i].text = inventory.GetItem(i).itemDecrs.description.ToString();
        }
        for (int i = inventory.GetSize(); i < icons.Count; i++)
        {
            icons[i].color = new Color(1, 1, 1, 0);
            icons[i].sprite = null;
            amounts[i].text = "";
            coast[i].text = "";
            descr[i].text = "";
        }
    }
    public void openShop()
    {
        upgrade.SetActive(false);
        shop.SetActive(true);
    }
    public void openUpgrade()
    {
        shop.SetActive(false);
        upgrade.SetActive(true);
    }
}
