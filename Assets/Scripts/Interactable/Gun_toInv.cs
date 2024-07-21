using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun_toInv : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] private string promt;
    [HideInInspector] public BaseForQuests bfq;
    public bool wasItcollected = false;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        wasItcollected = true;
        bfq.gun.isGunActive = true;
        bfq.gunn.SetActive(true);
        bfq.gunned.SetActive(true);
        bfq.gun.mew = true;
        this.gameObject.SetActive(false);
        bfq.isGunAndPatronsDrug = bfq.isGunAndPatronsDrug + 1;
        if (bfq.isGunAndPatronsDrug == 2)
        {
            bfq.goal.text = "Разберитесь с зомби за домом";
            bfq.zombies[0].SetActive(true);
            bfq.zombies[1].SetActive(true);
            bfq.smallAreaForQuest.SetActive(true);
            bfq.bigAreaForQuest.SetActive(true);
            bfq.tutorialsImg[3].SetActive(true);
        }
        return true;
    }

    public void LoadData(GameData data)
    {
        this.wasItcollected = data.wasGunCollected;
        if (wasItcollected == true)
        {
            this.gameObject.SetActive(false);
            if (bfq.numOfDialogueWithKris < 2)
            {
                bfq.zombies[0].SetActive(true);
                bfq.zombies[1].SetActive(true);
                bfq.smallAreaForQuest.SetActive(true);
                bfq.bigAreaForQuest.SetActive(true);
            }
        }
    }

    public void SaveData(GameData data)
    {
        data.wasGunCollected = this.wasItcollected;
    }

}
