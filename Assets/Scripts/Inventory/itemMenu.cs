using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class itemMenu : MonoBehaviour
{
    public GG player;
    public InventoryUI inv;

    public int i;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            hide();
        }
    }
    public void use()
    {
        player.use(i);
        hide();
    }
    public void drop()
    {
        player.drop(i);
        hide();
    }
    public void destroy()
    {
        player.destroy(i);
        hide();
    }
    public void pass()
    {
        player.pass(i);
        hide();
    }
    public void sell()
    {
        player.sell(i);
        hide();
    }
    public void show(Transform parent, int ind)
    {
        i = ind;
        transform.SetParent(parent, false);
        gameObject.SetActive(true);
    }
    public void hide()
    {
        gameObject.SetActive(false);
        inv.borders[i].gameObject.SetActive(false);
    }
}
