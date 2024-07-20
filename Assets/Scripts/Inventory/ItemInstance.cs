using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class ItemInstance
{
    [SerializeReference] public Item itemDecrs;
    public int amount = 1;
    public int damage;
    public bool use(GG player)
    {
        return itemDecrs.use(player, this);
    }
}

public class Stats
{
    public int health = 100;
    public int bull = 10;
    
}