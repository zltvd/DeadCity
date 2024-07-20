using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ShopInventory : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> items = new List<InventorySlot>();
    [SerializeField] private int size;
    [SerializeField] public UnityEvent OnInventoryChanged;
    public Inventory playInv;
    public GG gG;
    private void Start()
    {
        OnInventoryChanged.Invoke();
    }
    public int addItems(ItemInstance item)
    {
        foreach (InventorySlot slot in items)
        {
            if (slot.item.itemDecrs.id == item.itemDecrs.id)
                if (slot.item.amount < item.itemDecrs.max_stack)
                {
                    if ((slot.item.amount + item.amount) > slot.item.itemDecrs.max_stack)
                    {
                        item.amount -= slot.item.itemDecrs.max_stack - slot.item.amount;
                        slot.item.amount = slot.item.itemDecrs.max_stack;
                        continue;
                    }
                    slot.item.amount += item.amount;
                    OnInventoryChanged.Invoke();
                    return 0;
                }
        }
        if (items.Count >= size) return item.amount;
        while (item.amount > item.itemDecrs.max_stack)
        {
            ItemInstance itm = new ItemInstance();
            itm.itemDecrs = item.itemDecrs;
            itm.amount = item.itemDecrs.max_stack;
            items.Add(new InventorySlot(itm));
            item.amount -= item.itemDecrs.max_stack;
            if (items.Count >= size) return item.amount;
        }
        items.Add(new InventorySlot(item));
        OnInventoryChanged.Invoke();
        return 0;
    }
    public ItemInstance GetItem(int i)
    {
        return i < items.Count ? items[i].item : null;
    }
    public int GetAmount(int i)
    {
        return i < items.Count ? items[i].item.amount : 0;
    }
    public int GetSize()
    {
        return items.Count;
    }
    public void removeItem(int i)
    {
        if (i < items.Count)
        {
            items[i].item.amount--;
            if (items[i].item.amount <= 0)
                items.RemoveAt(i);
            OnInventoryChanged.Invoke();
        }
    }
    public void destroyItem(int i)
    {
        if (i < items.Count)
        {
            items.RemoveAt(i);
            OnInventoryChanged.Invoke();
        }
    }
    public void passItem(int i)
    {
        if (playInv.items.Count < playInv.size)
        {
            if (gG.coins >= items[i].item.itemDecrs.itemCoast * items[i].item.amount)
            {
                int a;
                a = playInv.addItems(this.GetItem(i));
                gG.coins -= items[i].item.itemDecrs.itemCoast * items[i].item.amount;
                if (a == 0)
                {
                    destroyItem(i);
                }
                else
                {
                    GetItem(i).amount = a;
                }
                OnInventoryChanged.Invoke();
            }
        }
    }
}
