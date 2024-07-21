using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BaseForQuests : MonoBehaviour, IDataPersistence
{
    public GameObject Lidia;
    public GameObject Shelterr;
    public GameObject Robert;
    public GameObject Kris;
    public GameObject Jess;
    public GameObject Steve;
    public GameObject player;
    public bool isMove;
    public Camera cam_forDialogue;
    public Camera cam_forBigMap;
    public Camera cam_forDialogue2;
    public Camera cam_FPS;
    public Inventory playInv;
    public CheastInventory chestInv;
    public GG gg;
    public TMP_Text quest;
    public TMP_Text goal;
    public bool isWave;
    public GameObject toHide;
    public Cam camer;
    public GameObject DWY;
    public TMP_Text dwy;
    public GameObject ShopPanel;
    public GameObject prizel;
    public Gunn gun;
    public GameObject gunn;
    public GameObject gunned;
    public GameObject elsePartsOfGun;
    public int numOfDialogueWithKris = 0;

    public bool isFirstRob;
    public bool isSecondRob;
    public bool isShopUnlock;
    public bool isAgainRob;

    [HideInInspector] public bool isAgainKris = false;
    [HideInInspector] public bool isAgainShelter;
     public bool isKrisMoving;

    [HideInInspector] public bool is2ndFloorUnlock;
     public bool isOutUnlock;

    public GameObject AllToHide;
    public Black_Screen_Fade fade_screen;
    public Shelter sht;
    public GameObject Map;
    public GameObject dialogueSystem;
    public GameObject dialoguePanel;
    public GameObject questPanel;
    public int isGunAndPatronsDrug;
    public int wichChest;
    public Camera camForShop;

    public List<GameObject> zombies;

    public TMP_Text plusMoney;
    public GameObject aboutPlusCoins;

    public GameObject smallAreaForQuest;
    public GameObject bigAreaForQuest;
    public GameObject TriggerFor2qst;
    public GameObject TriggerFor3qst;
    public GameObject invToHide;

    public GameObject sellButton;
    public GameObject passButton;

    public MeshRenderer gunRender;
    public MeshRenderer ggRender;

    public bool isStop;
    public bool isSecondFinish;

    [HideInInspector] public ItemInstance puli;
    [HideInInspector] public ItemInstance granata;

    [HideInInspector] public ItemInstance puli_forBoss;
    [HideInInspector] public ItemInstance granata_forBoss;
    public bool isEscActive;

    public GameObject areaBoss;
    public GameObject sliderBossHP;
    public GameObject triggerForBoss;
    public GameObject mainCamera;

    public GameObject allHP;
    public GameObject winPanel;
    public bool isGameOver = false;
    public float killedZombie = 7;
    public GameObject cameraForKris;

    public GameObject allZombies;
    public GameObject[] tutorialsImg;
    public GameObject triggerForDelete;

    public bool isMapAndQuestAreActive = false;
    private void Start()
    {
        cam_forDialogue.enabled = false;
        cam_FPS.enabled = true;
    }

    public void LoadData(GameData data)
    {
        this.isSecondFinish = data.isSecondFinish;
        this.isWave = data.isWave;
        this.isMove = data.isMove;

        this.numOfDialogueWithKris = data.numOfDialogueWithKris;

        this.isKrisMoving = data.isKrisMoving;

        this.isFirstRob = data.isFirstRob;
        this.isSecondRob = data.isSecondRob;
        this.isAgainRob = data.isAgainRob;
        this.isShopUnlock = data.isShopUnlock;

        this.isAgainKris = data.isAgainKris;
        this.isAgainShelter = data.isAgainShelter;
        this.is2ndFloorUnlock = data.isSecondFloorUnlock;
        this.isOutUnlock = data.isOutUnlock;

        this.isGunAndPatronsDrug = data.isGunAndPatrons;
        this.isStop = data.isStop;
        this.isEscActive = data.isEscActive;
        

        this.quest.text = data.textOfQuest;
        this.goal.text = data.textOfGoal;

        this.isMapAndQuestAreActive = data.isMapAndQuestAreActive;
        if (isMapAndQuestAreActive == true)
        {
            this.questPanel.SetActive(true);
            this.Map.SetActive(true);
            this.gg.isCanMap = true;
            Destroy(GameObject.Find("Dialogue with Lidia"));
            Destroy(GameObject.Find("Meet with Lidia"));
            Destroy(GameObject.Find("Medkit_tr"));
            Destroy(GameObject.Find("Medkit_tr_use"));
            Destroy(GameObject.Find("DWY_1"));
            Destroy(GameObject.Find("DWY_2"));
            Destroy(GameObject.Find("DWY_3"));
            Lidia.SetActive(false);
        }
        if (numOfDialogueWithKris >= 8 && numOfDialogueWithKris < 11)
        {
            Lidia.SetActive(true);
            //Lidia.GetComponent<Lidia>().animator.SetBool("isSit", true);
            Jess.GetComponent<Jess>().animator.SetBool("isSit", true);
            Jess.transform.position = new Vector3(21.65f, 0.2f, 21.5f);
            Jess.transform.eulerAngles = new Vector3(-5.6f, 97f, -0.7f);
            Lidia.GetComponent<Animator>().SetBool("isSit", true);
        }
        if (numOfDialogueWithKris >= 11)
        {
            zombies[9].SetActive(false);
            GameObject.Find("Trigger for Boss").SetActive(false);
        }
    }
    public void SaveData(GameData data)
    {
        data.isSecondFinish = this.isSecondFinish;
        data.isWave = this.isWave;
        data.isMove = this.isMove;

        data.numOfDialogueWithKris = this.numOfDialogueWithKris;

        data.isKrisMoving = this.isKrisMoving;

        data.isFirstRob = this.isFirstRob;
        data.isSecondRob = this.isSecondRob;
        data.isAgainRob = this.isAgainRob;
        data.isShopUnlock = this.isShopUnlock;

        data.isAgainKris = this.isAgainKris;
        data.isAgainShelter = this.isAgainShelter;
        data.isSecondFloorUnlock = this.is2ndFloorUnlock;
        data.isOutUnlock = this.isOutUnlock;

        data.isGunAndPatrons = this.isGunAndPatronsDrug;
        data.isStop = this.isStop;
        data.isEscActive = this.isEscActive;

        data.textOfQuest = this.quest.text;
        data.textOfGoal = this.goal.text;

        data.isMapAndQuestAreActive = this.isMapAndQuestAreActive;
    }
}
