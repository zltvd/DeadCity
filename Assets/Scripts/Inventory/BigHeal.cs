using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[CreateAssetMenu(menuName = "inventory/Potion")]
public class BigHeal : Item
{
    public int healing;
    public int playerHP;
    public static bool isGameOver;
    public TextMeshProUGUI playerHPText;
    public GG player;
    public override bool use(GG player, ItemInstance itemData)
    {
        player.currentHealth += healing;
        return true;
    }
}
