using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Kris : MonoBehaviour, IInteractable, IDataPersistence
{
    [SerializeField] private string promt;

    public BaseForQuests bfq;
    public Camera cam_forDialogue;
    public Camera cam_forDialogue2;
    public Camera cam_forDialogue3;
    public Camera cam_forDialogue4;
    public Camera cam_forDialogue5;
    public GameObject Einteract;
    public Cam camer;
    public Animator animator;
    Quaternion camRot;
    Rigidbody rb;
    public NavMeshAgent nav;
    public string InteractionPromt => promt;

    public GameObject obj;
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public float speed;
    private Vector3 actualPoints;
    public int x;
    public bool isGigant;
    public GameObject hideEverything;

    public bool Interact(Interact interactor)
    {
        Einteract.SetActive(false);
        cam_forDialogue.enabled = true;
        bfq.cam_FPS.enabled = false;
        bfq.gg.isDialogue = true;
        //bfq.toHide.SetActive(false);
        camer.cursCanMove = false;
        bfq.ggRender.enabled = false;
        bfq.gunRender.enabled = false;
        bfq.invToHide.SetActive(false);
        bfq.elsePartsOfGun.SetActive(false);
        bfq.AllToHide.SetActive(false);
        if (bfq.numOfDialogueWithKris == 0)
        {
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(0);
            bfq.isOutUnlock = true;
            bfq.quest.text = "С чистого листа";
            bfq.goal.text = "Найдите оружие и патроны";
            bfq.isAgainShelter = true;
            bfq.isAgainKris = true;
        }
        if (bfq.numOfDialogueWithKris == 1)
        {
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(1);

        }
        if (bfq.gun.isSimpleZombiesDead == true)
        {
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(2);
            bfq.isAgainRob = false;
            bfq.isSecondRob = true;
        }
        if (bfq.numOfDialogueWithKris == 3)
        {
            bfq.cam_forDialogue.enabled = true;
            bfq.gun.mew = false; 
            bfq.Kris.GetComponent<NPC>().interact(3);
            bfq.cam_forBigMap.enabled = true;
            bfq.TriggerFor2qst.SetActive(true);
            bfq.mainCamera.GetComponent<Camera>().enabled = false;
        }
        if (bfq.numOfDialogueWithKris == 4)
        {
            bfq.gun.mew = false;
            cam_forDialogue.enabled = false;
            cam_forDialogue2.enabled = true;
            bfq.cam_forBigMap.enabled = true;
            bfq.Robert.GetComponent<Shop_Robert>().cam_forDialogue.enabled = false;
            bfq.Kris.GetComponent<NPC>().interact(4);
            Destroy(bfq.TriggerFor2qst);
            bfq.goal.text = "Следуйте за Крисом";
        }
        if (bfq.numOfDialogueWithKris == 6)
        {
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(6);
        }
        if (bfq.numOfDialogueWithKris == 7)
        {
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(7);
            bfq.isSecondFinish = true;
            bfq.cam_forDialogue2.enabled = true;
            bfq.Kris.GetComponent<NPC>().isGoToZombie = false;
        }
        if (bfq.numOfDialogueWithKris == 8)
        {
            hideEverything.SetActive(false);
            cam_forDialogue2.enabled = false;
            cam_forDialogue3.enabled = true;
            //cam_forDialogue3.GetComponent<AudioListener>().enabled = false;
            bfq.gun.mew = false;
            bfq.AllToHide.SetActive(false);
            bfq.invToHide.SetActive(false);
            bfq.Kris.GetComponent<NPC>().interact(8);
        }
        if (bfq.numOfDialogueWithKris == 9)
        {
            cam_forDialogue3.enabled = true;
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(9);
        }
        if (bfq.numOfDialogueWithKris == 10)
        {
            //bfq.mainCamera.SetActive(false);
            cam_forDialogue4.enabled = true;
            //cam_forDialogue4.GetComponent<AudioListener>().enabled = false;
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(10);
            bfq.triggerForBoss.SetActive(true);
            bfq.goal.text = "Сразитесь с гигантом";
            isGigant = true;
        }
        if (bfq.numOfDialogueWithKris == 11)
        {
            cam_forDialogue.enabled = false;
            cam_forDialogue5.enabled = true;
            bfq.gun.mew = false;
            bfq.Kris.GetComponent<NPC>().interact(11);
            bfq.goal.text = " ";
            bfq.quest.text = " ";
        }
        return true;
    }
    private void Start()
    {
        cam_forDialogue.enabled = false;
        x = 1;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (bfq.isKrisMoving == true)
        {
            Walking();
            rb.isKinematic = false;
        }
        else
        {
            animator.SetBool("isRun", false);
            rb.isKinematic = true;
        }
    }
    public void Walking()
    {
        animator.SetBool("isRun", true);
        obj.transform.LookAt(pathPoints[x].transform);
        actualPoints = obj.transform.position;
        obj.transform.position = Vector3.MoveTowards(actualPoints, pathPoints[x].transform.position, speed * Time.deltaTime);
    }
    public void LoadData(GameData data)
    {
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.transform.position = data.KrisPosition;

        camRot.eulerAngles = data.KrisRotation;
        this.transform.rotation = camRot;
        this.GetComponent<NavMeshAgent>().enabled = true;

        this.GetComponent<NPC>().isGoToZombie = data.isZombieFor2ndQuestAreActive;
        if (this.GetComponent<NPC>().isGoToZombie == true)
        {
            for (int i = 2; i < 9; i++)
            {
                if (bfq.zombies[i].GetComponent<enemyscr>().hp > 0)
                {
                    bfq.zombies[i].SetActive(true);
                }
                else
                {
                    bfq.zombies[i].SetActive(false);
                }
            }
        }

        this.isGigant = data.isGigantActive;
        if (isGigant == true)
        {
            bfq.triggerForBoss.SetActive(true);
            bfq.zombies[9].SetActive(true);
        }
    }
    public void SaveData(GameData data)
    {
        data.KrisPosition = this.transform.position;

        data.KrisRotation = this.transform.rotation.eulerAngles;

        data.isZombieFor2ndQuestAreActive = this.GetComponent<NPC>().isGoToZombie;
        data.isGigantActive = this.isGigant;
    }
}
