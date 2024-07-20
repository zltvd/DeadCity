using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum item_type { potion = 1, bullet = 2, grenade = 3, bigpotion = 4 }
public abstract class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int itemCoast;
    public int max_stack;
    public Sprite icon;
    public GameObject prefab;
    public item_type type;
    public string action;
    public string description;
    public abstract bool use(GG player, ItemInstance itemData);
}
