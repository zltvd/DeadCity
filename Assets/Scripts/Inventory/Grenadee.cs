using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "inventory/Grenade")]
public class Grenadee : Item
{
    public override bool use(GG player, ItemInstance itemData)
    {
        player.gnd.ThrowGrenade();
        return true;
    }
}
