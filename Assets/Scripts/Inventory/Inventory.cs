using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InventorySlot
{
    public ItemInstance item;
    public bool equiped;
    public InventorySlot(ItemInstance item)
    {
        this.item = item;
        this.equiped = false;
    }
}
public class Inventory : MonoBehaviour
{
    [SerializeField] public List<InventorySlot> items;
    [SerializeField] public int size;
    [SerializeField] public UnityEvent OnInventoryChanged;
    public CheastInventory chestInventory;
    public ShopInventory shopInventory;
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
    public void dropItem(int i)
    {
        if (i < items.Count)
        {
            GameObject pref = items[i].item.itemDecrs.prefab;
            GameObject o = Instantiate(pref, transform.position/3 + transform.forward*3, pref.transform.rotation);
            o.GetComponent<ItemContainer>().item = items[i].item;
            o.layer = 7;
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
        a = chestInventory.addItems(this.GetItem(i));
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
    public void sellItem(int i)
    {
        int b = items[i].item.itemDecrs.itemCoast;
        b = b * items[i].item.amount;
        gG.coins += b;
        destroyItem(i);
        OnInventoryChanged.Invoke();
    }

    public int addItemToSlot(Item item, int amount, int slotId)
    {
        InventorySlot slot = items[slotId];
        ItemInstance itm = new ItemInstance();
        slot.item = itm;
        
        if (amount < item.max_stack)
        {
            slot.item.amount = amount;
            slot.item.itemDecrs = item;

            itm.itemDecrs = item;
            itm.amount = item.max_stack;
            items.Add(new InventorySlot(itm));
            if (items.Count >= size) return itm.amount;
        }
        items.Add(new InventorySlot(itm));
        OnInventoryChanged.Invoke();
        return 0;



        //foreach (InventorySlot slot in items)
        //{
        //    if (slot.item.itemDecrs.id == item.itemDecrs.id)
        //        if (slot.item.amount < item.itemDecrs.max_stack)
        //        {
        //            if ((slot.item.amount + item.amount) > slot.item.itemDecrs.max_stack)
        //            {
        //                item.amount -= slot.item.itemDecrs.max_stack - slot.item.amount;
        //                slot.item.amount = slot.item.itemDecrs.max_stack;
        //                continue;
        //            }
        //            slot.item.amount += item.amount;
        //            OnInventoryChanged.Invoke();
        //            return 0;
        //        }
        //}
        //if (items.Count >= size) return item.amount;
        //while (item.amount > item.itemDecrs.max_stack)
        //{
        //    ItemInstance itm = new ItemInstance();
        //    itm.itemDecrs = item.itemDecrs;
        //    itm.amount = item.itemDecrs.max_stack;
        //    items.Add(new InventorySlot(itm));
        //    item.amount -= item.itemDecrs.max_stack;
        //    if (items.Count >= size) return item.amount;
        //}
        //items.Add(new InventorySlot(item));
        //OnInventoryChanged.Invoke();
        //return 0;
    }
    public void removeItemsFromSlot(int i)
    {
        ItemInstance item = GetComponent<Inventory>().GetItem(i);
        if (item == null) return;
            items.RemoveAt(i);
            OnInventoryChanged.Invoke();
        
    }
}
