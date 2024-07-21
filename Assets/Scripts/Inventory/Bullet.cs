using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(menuName = "inventory/Bullet")]

public class Bullet : Item
{
    public int bullet;
    public override bool use(GG player, ItemInstance itemData)
    {
        player.patrons += bullet;
        if (player.patrons > player.maxPatrons)
        {
            player.patrons = player.maxPatrons;
        }
        return true;
    }
}
