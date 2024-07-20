using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Shelter : MonoBehaviour, IInteractable
{
    [SerializeField] private string promt;
    public Camera cam_forDialogue;
    public BaseForQuests bfq;
    public Cam camer;
    public GameObject Einteract;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        if (bfq.numOfDialogueWithKris == 0)
        {
            bfq.gun.mew = false;
            bfq.Shelterr.GetComponent<NPC>().interact(0);
            bfq.quest.text = "С чистого листа";
            bfq.goal.text = "Найдите того, с кем говорили";
        }
        if (bfq.isAgainShelter == true)
        {
            bfq.gun.mew = false;
            bfq.Shelterr.GetComponent<NPC>().interact(1);
        }
        if (bfq.isSecondFinish == true)
        {
            bfq.goal.text = "Поговорите с ребятами";
        }
        camer.cursCanMove = false;
        Einteract.SetActive(false);
        cam_forDialogue.enabled = true;
        bfq.cam_FPS.enabled = false;
        bfq.gg.isDialogue = true;
        //bfq.toHide.SetActive(false);
        bfq.invToHide.SetActive(false);
        for (int i = 0; i < 22; i++)
        {
            bfq.zombies[i].GetComponent<AudioSource>().enabled = false;

        }
        return true;
    }
    private void Start()
    {
        cam_forDialogue.enabled = false;
    }
}
