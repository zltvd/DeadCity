using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] private string promt;
    [HideInInspector] public BaseForQuests bfq;
    [HideInInspector] public CheastInventory inventory;
    private bool isInvBoxWasntEmpty;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        bfq.passButton.SetActive(true);
        bfq.sellButton.SetActive(false);
        Time.timeScale = 0f;
        bfq.gg.invui.showChestMenu();
        bfq.gg.isOpened = true;
        bfq.AllToHide.SetActive(false);
        bfq.gg.Blur.enabled = true;
        bfq.isGunAndPatronsDrug = bfq.isGunAndPatronsDrug + 1;
        if (bfq.isGunAndPatronsDrug == 2)
        {
            bfq.goal.text = "Разберитесь с зомби за домом";
            bfq.zombies[0].SetActive(true);
            bfq.zombies[1].SetActive(true);
            bfq.smallAreaForQuest.SetActive(true);
            bfq.bigAreaForQuest.SetActive(true);
            bfq.tutorialsImg[3].SetActive(true);
        }
        return true;
    }
    public void LoadData(GameData data)
    {
        this.isInvBoxWasntEmpty = data.isInvBoxWasntEmpty;
        if (this.isInvBoxWasntEmpty == true)
        {
            for (int i = 14; i >= 0; i--)
            {
                bfq.chestInv.removeItemsFromSlot(i);
            }
        }
        for (int i = 0; i < data.itemNamesBoxInv.Length; i++)
        {
            if (this.isInvBoxWasntEmpty == true)
            {
                if (data.itemNamesBoxInv[i].Trim().Length != 0)
                {
                    Item item = Resources.Load<Item>($"ScrObjects/{data.itemNamesBoxInv[i]}");
                    InventorySlot newItem = new InventorySlot(new ItemInstance());
                    newItem.item.itemDecrs = item;
                    newItem.item.amount = data.itemAmountsBoxInv[i];
                    bfq.chestInv.items.Add(newItem);
                    bfq.chestInv.OnInventoryChanged.Invoke();
                }
            }

        }
    }
    public void SaveData(GameData data)
    {
        data.itemNamesBoxInv = new string[bfq.chestInv.items.Count];
        data.itemAmountsBoxInv = new int[bfq.chestInv.items.Count];

        for (int i = 0; i < bfq.chestInv.items.Count; i++)
        {
            if (bfq.chestInv.items[i].item != null)
            {
                data.isInvBoxWasntEmpty = true;
                data.itemNamesBoxInv[i] = bfq.chestInv.GetItem(i).itemDecrs.itemName;
                data.itemAmountsBoxInv[i] = bfq.chestInv.GetItem(i).amount;
            }

        }
    }
}