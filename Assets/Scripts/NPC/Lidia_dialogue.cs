using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidia_dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] private string promt;
    public BaseForQuests bfq;
    public Cam camer;
    public GameObject Einteract;
    public Camera cam_forDialogue;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        bfq.gun.mew = false;
        if (bfq.isSecondFinish == false)
        {
            cam_forDialogue.enabled = true;
            bfq.Lidia.GetComponent<NPC>().interact(1);
        }
        if (bfq.numOfDialogueWithKris == 8)
        {
            cam_forDialogue.enabled = false;
            bfq.Kris.GetComponent<Kris>().hideEverything.SetActive(false);
            bfq.Kris.GetComponent<Kris>().cam_forDialogue3.enabled = true;
            bfq.gun.mew = false;
            bfq.Lidia.GetComponent<NPC>().interact(2);
        }
        if (bfq.numOfDialogueWithKris == 9)
        {
            cam_forDialogue.enabled = false;
            bfq.Kris.GetComponent<Kris>().cam_forDialogue3.enabled = true;
            bfq.Kris.GetComponent<Kris>().hideEverything.SetActive(false);
            bfq.gun.mew = false;
            bfq.Lidia.GetComponent<NPC>().interact(3);
        }
        bfq.player.SetActive(false);
        bfq.invToHide.SetActive(false);
        camer.cursCanMove = false;
        Einteract.SetActive(false);
        bfq.cam_FPS.enabled = false;
        bfq.gg.isDialogue = true;
        bfq.toHide.SetActive(false);
        return true;
    }
    private void Start()
    {
        cam_forDialogue.enabled = false;
    }
}
