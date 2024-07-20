using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CheastInventory : MonoBehaviour
{
    [SerializeField] public List<InventorySlot> items;
    [SerializeField] private int size;
    [SerializeField] public UnityEvent OnInventoryChanged;
    public Inventory playInv;
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
        Debug.Log(items.Count);
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
        int a;
        a = playInv.addItems(this.GetItem(i));
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
    public void removeItemsFromSlot(int i)
    {
        ItemInstance item = GetComponent<CheastInventory>().GetItem(i);
        if (item == null) return;
        items.RemoveAt(i);
        OnInventoryChanged.Invoke();

    }
}
