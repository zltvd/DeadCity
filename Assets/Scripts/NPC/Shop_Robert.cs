using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_Robert : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] private string promt;

    public BaseForQuests bfq;
    public Camera cam_forDialogue;
    public Camera cam_forShop;
    public GameObject Einteract;
    public Cam camer;
    Quaternion camRot;

    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        
        if (bfq.isFirstRob == true)
        {
            cam_forDialogue.enabled = true;
            bfq.gun.mew = false;
            bfq.Robert.GetComponent<NPC>().interact(0);
            bfq.goal.text = "Поговорите с Крисом на 2 этаже";
            bfq.isFirstRob = false;
            bfq.is2ndFloorUnlock = true;
        }
        if (bfq.isAgainRob == true)
        {
            cam_forDialogue.enabled = true;
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<Kris>().cam_forDialogue.enabled = false;
            bfq.Robert.GetComponent<NPC>().interact(1);
        }
        if (bfq.isSecondRob == true)
        {
            cam_forDialogue.enabled = true;
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<Kris>().cam_forDialogue.enabled = false;
            bfq.Robert.GetComponent<NPC>().interact(3);
            if (bfq.numOfDialogueWithKris < 3)
            {
                bfq.numOfDialogueWithKris = 3;
                bfq.quest.text = "Пропавшие";
                bfq.goal.text = "Поговорите с Крисом";
            }
        }
        if(bfq.isShopUnlock == true)
        {
            cam_forDialogue.enabled = true;
            bfq.gun.mew = false;
            bfq.Robert.GetComponent<NPC>().interact(2);
            bfq.sellButton.SetActive(true);
            bfq.passButton.SetActive(false);
        }
        if (bfq.numOfDialogueWithKris == 8)
        {
            bfq.Kris.GetComponent<Kris>().cam_forDialogue3.enabled = true;
            bfq.Kris.GetComponent<Kris>().hideEverything.SetActive(false);
            bfq.gun.mew = false;
            bfq.Robert.GetComponent<NPC>().interact(4);
        }
        if (bfq.numOfDialogueWithKris == 9)
        {
            cam_forDialogue.enabled = true;
            bfq.gun.mew = false;
            bfq.Robert.GetComponent<NPC>().interact(2);
            bfq.sellButton.SetActive(true);
            bfq.passButton.SetActive(false);
        }
        if (bfq.numOfDialogueWithKris == 10)
        {
            cam_forDialogue.enabled = false;
            bfq.player.GetComponent<GG>().cam.enabled = false;
            bfq.Kris.GetComponent<Kris>().cam_forDialogue4.enabled = true;
            bfq.gun.mew = false;
            bfq.Robert.GetComponent<NPC>().interact(5);
            bfq.triggerForBoss.SetActive(true);
            bfq.goal.text = "Сразитесь с гигантом";
        }
        if (bfq.numOfDialogueWithKris == 11)
        {
            cam_forDialogue.enabled = false;
            bfq.Kris.GetComponent<Kris>().cam_forDialogue5.enabled = true;
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(6);
            bfq.goal.text = " ";
            bfq.quest.text = " ";
        }
        Einteract.SetActive(false);
        bfq.cam_FPS.enabled = false;
        bfq.gg.isDialogue = true;
        //bfq.toHide.SetActive(false);
        camer.cursCanMove = false;
        bfq.ggRender.enabled = false;
        bfq.gunRender.enabled = false;
        bfq.AllToHide.SetActive(false);
        bfq.invToHide.SetActive(false);
        bfq.allHP.SetActive(false);
        bfq.elsePartsOfGun.SetActive(false);
        return true;
    }
    private void Start()
    {
        cam_forDialogue.enabled = false;
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.RobertPosition;

        camRot.eulerAngles = data.RobertRotation;
        this.transform.rotation = camRot;
    }
    public void SaveData(GameData data)
    {
        data.RobertPosition = this.transform.position;

        data.RobertRotation = this.transform.rotation.eulerAngles;
    }
}
