using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    [SerializeField] public ItemInstance item;
    public void pichUp(GameObject o)
    {
        int amount = o.GetComponent<Inventory>().addItems(item);
        if (amount == 0)
        {
            gameObject.SetActive(false);
        }
        else
            item.amount = amount;
    }
}
