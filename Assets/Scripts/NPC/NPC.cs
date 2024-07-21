using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using TMPro;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public BaseForQuests bfq;
    public float IsStand = 0;
    [SerializeField] private List<Object> dialogues = new List<Object>();
    public bool isGoToZombie;
    public void interact(int i)
    {
        bfq.dialogueSystem.GetComponent<Dialogue_System>().loadDialog(dialogues[i]);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("start race", startQuest);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("shelter", inShelter);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("open shop", openShop);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("add coins", addCoins);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("dialogue end", endDalogue);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("end 1st qst", firstFinish);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("tp to 2nd", tpToSec);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("go to 2nd", goToSec);
        bfq.dialogueSystem.GetComponent<Dialogue_System>().setAction("standKris", standKris);
    }
    private void Update()
    {
        if (IsStand == 1)
        {
            bfq.Kris.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime);
            bfq.Jess.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 270, 0), Time.deltaTime);
            
        }
        if (IsStand == 2)
        {
            bfq.Kris.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);
            bfq.Jess.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 90, 0), Time.deltaTime);

        }
    }
    public void tpToSec()
    {
        bfq.Kris.GetComponent<Kris>().cam_forDialogue.enabled = false;
        bfq.fade_screen.x_p = 28.23f;
        bfq.fade_screen.y_p = 1f;
        bfq.fade_screen.z_p = -46.9f;

        bfq.fade_screen.X_R = -0.3f;
        bfq.fade_screen.Y_R = 172.86f;
        bfq.fade_screen.Z_R = -0.006f;
        bfq.cam_forBigMap.enabled = true;
        bfq.gun.mew = true;
        bfq.fade_screen.fade_enabled = true;
        bfq.dialoguePanel.SetActive(false);
        bfq.gg.isDialogue = false;
        bfq.sht.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.camer.cursCanMove = true;
        bfq.ggRender.enabled = true;
        bfq.gunRender.enabled = true;
        bfq.Kris.GetComponent<NavMeshAgent>().enabled = false;
        bfq.Kris.transform.position = new Vector3(28.3f, -0.004f, -53.3f);
        bfq.Kris.transform.eulerAngles = new Vector3(-0.3f, 38.7f, -0.002f);
        bfq.Kris.GetComponent<NavMeshAgent>().enabled = true;
        bfq.invToHide.SetActive(true);
        bfq.numOfDialogueWithKris = 4;
        bfq.cam_forBigMap.enabled = false;
        bfq.mainCamera.SetActive(true);
        for (int i = 0; i < 22; i++)
        {
            bfq.zombies[i].GetComponent<AudioSource>().enabled = true;

        }
    }
    public void goToSec()
    {
        bfq.Kris.GetComponent<Kris>().cam_forDialogue.enabled = false;
        Time.timeScale = 1f;
        bfq.gg.shopPanel.SetActive(false);
        bfq.dialoguePanel.SetActive(false);
        bfq.questPanel.SetActive(true);
        bfq.gg.isDialogue = false;
        bfq.ggRender.enabled = true;
        bfq.gunRender.enabled = true;
        bfq.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.Map.SetActive(true);
        bfq.camer.cursCanMove = true;
        bfq.AllToHide.SetActive(true);
        bfq.invToHide.SetActive(true);
        bfq.goal.text = "Доберитесь до места встречи с Крисом";
        bfq.TriggerFor2qst.SetActive(true);
        bfq.numOfDialogueWithKris = 6;
        bfq.gun.mew = true;
        bfq.cam_forBigMap.enabled = false;
        bfq.mainCamera.SetActive(true);
    }
    public void firstFinish()
    {
        bfq.camForShop.enabled = false;
        bfq.dialoguePanel.SetActive(false);
        bfq.questPanel.SetActive(true);
        bfq.gg.isDialogue = false;
        bfq.ggRender.enabled = true;
        bfq.gunRender.enabled = true;
        bfq.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.Map.SetActive(true);
        bfq.camer.cursCanMove = true;
        bfq.AllToHide.SetActive(true);
        bfq.invToHide.SetActive(true);
        bfq.allHP.SetActive(true);
        if (bfq.isSecondRob == true)
        {
            bfq.isSecondRob = false;
            bfq.isShopUnlock = true;
        }
        bfq.gun.mew = true;
        bfq.gg.coins = bfq.gg.coins + 300;
        bfq.aboutPlusCoins.GetComponent<Delete_DWY>().startTime = 0;
        bfq.aboutPlusCoins.SetActive(true);
        bfq.plusMoney.text = "+ 300";
    }
    public void endDalogue()
    {
        Time.timeScale = 1f;
        bfq.allHP.SetActive(true);
        bfq.camForShop.enabled = false;
        bfq.Kris.GetComponent<Kris>().cam_forDialogue.enabled = false;
        bfq.Kris.GetComponent<Kris>().cam_forDialogue2.enabled = false;
        bfq.Kris.GetComponent<Kris>().cam_forDialogue3.enabled = false;
        bfq.Kris.GetComponent<Kris>().cam_forDialogue4.enabled = false;
        bfq.Kris.GetComponent<Kris>().cam_forDialogue5.enabled = false;
        bfq.cam_forDialogue2.enabled = false;
        bfq.gg.shopPanel.SetActive(false);
        bfq.dialoguePanel.SetActive(false);
        bfq.questPanel.SetActive(true);
        bfq.gg.isDialogue = false;
        bfq.ggRender.enabled = true;
        bfq.gunRender.enabled = true;
        bfq.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.Map.SetActive(true);
        bfq.camer.cursCanMove = true;
        bfq.invToHide.SetActive(true);
        bfq.AllToHide.SetActive(true);
        bfq.prizel.SetActive(true);
        bfq.player.SetActive(true);
        bfq.elsePartsOfGun.SetActive(true);
        bfq.cam_forBigMap.enabled = false;
        if (bfq.isFirstRob == false)
            bfq.isAgainRob = true;

        if (bfq.numOfDialogueWithKris == 0 && bfq.isAgainKris == true)
            bfq.numOfDialogueWithKris = 1;

        if (bfq.numOfDialogueWithKris == 4)
        {
            bfq.Kris.GetComponent<Kris>().Walking();
            bfq.isKrisMoving = true;
        }
        if (bfq.gun.isSimpleZombiesDead == true)
        {
            bfq.quest.text = "С чистого листа";
            bfq.goal.text = "Поговорите с Робертом";
            bfq.gun.isSimpleZombiesDead = false;
        }
        if (isGoToZombie == true)
        {
            Item item = Resources.Load<Item>($"ScrObjects/Bullet");
            InventorySlot newItem = new InventorySlot(new ItemInstance());
            newItem.item.itemDecrs = item;
            newItem.item.amount = 100;
            bfq.playInv.addItems(newItem.item);

            Item itemG = Resources.Load<Item>($"ScrObjects/Grenade");
            InventorySlot newItemG= new InventorySlot(new ItemInstance());
            newItemG.item.itemDecrs = itemG;
            newItemG.item.amount = 3;
            bfq.playInv.addItems(newItemG.item);
            bfq.playInv.OnInventoryChanged.Invoke();

            IsStand = 2;
            bfq.smallAreaForQuest.transform.position = new Vector3(-926.2f, -520.26f, -122.9f);
            bfq.bigAreaForQuest.transform.position = new Vector3(-926.2f, -520.26f, -122.8f);
            bfq.smallAreaForQuest.SetActive(true);
            bfq.bigAreaForQuest.SetActive(true);

            for (int i = 2; i < 9; i++)
            {
                bfq.zombies[i].SetActive(true);
            }
            bfq.playInv.OnInventoryChanged.Invoke();
        }
        if (bfq.isSecondFinish == true)
        {
            IsStand = 0;
            bfq.gg.coins = bfq.gg.coins + 600;
            bfq.aboutPlusCoins.GetComponent<Delete_DWY>().startTime = 0;
            bfq.aboutPlusCoins.SetActive(true);
            bfq.plusMoney.text = "+ 600";
            bfq.quest.text = "Последний рывок";
            bfq.goal.text = "Вернитесь в убежище";
            bfq.TriggerFor3qst.SetActive(true);
            bfq.isSecondFinish = false;
        }

        if (bfq.numOfDialogueWithKris == 8)
        {
            bfq.goal.text = "Встретьтесь с Крисом и Робертом на улице";
            bfq.Robert.transform.position = new Vector3(27.37f, 0.089f, 22.38f);
            bfq.Robert.transform.eulerAngles = new Vector3(0f, -56f, 0f);
            bfq.numOfDialogueWithKris = 9;
        }
        if (bfq.numOfDialogueWithKris == 10)
        {
            Item item = Resources.Load<Item>($"ScrObjects/Bullet");
            InventorySlot newItem = new InventorySlot(new ItemInstance());
            newItem.item.itemDecrs = item;
            newItem.item.amount = 100;
            bfq.playInv.addItems(newItem.item);

            Item itemG = Resources.Load<Item>($"ScrObjects/Grenade");
            InventorySlot newItemG = new InventorySlot(new ItemInstance());
            newItemG.item.itemDecrs = itemG;
            newItemG.item.amount = 2;
            bfq.playInv.addItems(newItemG.item);
            bfq.playInv.OnInventoryChanged.Invoke();

            bfq.playInv.OnInventoryChanged.Invoke();
        }
        if (bfq.numOfDialogueWithKris == 11)
        {
            bfq.gg.coins = bfq.gg.coins + 2000;
            bfq.aboutPlusCoins.GetComponent<Delete_DWY>().startTime = 0;
            bfq.aboutPlusCoins.SetActive(true);
            bfq.plusMoney.text = "+ 2000 coins";
            bfq.Kris.SetActive(false);
            bfq.Jess.SetActive(false);
            bfq.Steve.SetActive(false);
            bfq.Lidia.SetActive(false);
            bfq.Robert.transform.position = new Vector3(27.37f, 0.089f, 22.38f);
            bfq.Robert.transform.eulerAngles = new Vector3(0f, -56f, 0f);
            bfq.numOfDialogueWithKris = 12;
            bfq.isGameOver = true;
            Destroy(bfq.questPanel);
            //bfq.questPanel.SetActive(false);
        }

        bfq.gun.mew = true;
    }
    public void startQuest()
    {
        bfq.dialoguePanel.SetActive(false);
        bfq.questPanel.SetActive(true);
        bfq.isMapAndQuestAreActive = true;
        bfq.invToHide.SetActive(true);
        bfq.gg.isDialogue = false;
        bfq.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.Map.SetActive(true);
        bfq.gg.isCanMap = true;
        bfq.camer.cursCanMove = true;
        bfq.gun.mew = true;
        bfq.cam_forBigMap.enabled = false;
        bfq.isEscActive = true;
    }
    public void addCoins()
    {
        bfq.gg.coins = bfq.gg.coins + 120;
        bfq.gg.coinsText.text = "Coins: " + bfq.gg.coins.ToString();
        bfq.dialoguePanel.SetActive(false);
        bfq.gg.isDialogue = false;
        bfq.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.camer.cursCanMove = true;
    }
    public void openShop()
    {
        bfq.dialoguePanel.SetActive(false);
        bfq.gg.isDialogue = false;
        bfq.camForShop.enabled = true;
        bfq.cam_FPS.enabled = false;
        bfq.ShopPanel.SetActive(true);
        bfq.AllToHide.SetActive(false);
        bfq.invToHide.SetActive(true);
        bfq.questPanel.SetActive(false);
        bfq.Map.SetActive(false);
        bfq.prizel.SetActive(false);
        bfq.elsePartsOfGun.SetActive(false);
    }
    public void inShelter()
    {
        bfq.fade_screen.x_p = 22.4f;
        bfq.fade_screen.y_p = 1.05F;
        bfq.fade_screen.z_p = 25.8f;

        bfq.fade_screen.X_R = -0.3f;
        bfq.fade_screen.Y_R = -202.2f;
        bfq.fade_screen.Z_R = 0f;
        bfq.gun.mew = true;
        bfq.fade_screen.fade_enabled = true;
        bfq.dialoguePanel.SetActive(false);
        bfq.invToHide.SetActive(true);
        bfq.gg.isDialogue = false;
        bfq.sht.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
        bfq.camer.cursCanMove = true;
    }
    public void standKris()
    {
        IsStand = 1;
        bfq.Kris.GetComponent<Kris>().animator.SetBool("isKnee", false);
        isGoToZombie = true;
        bfq.Jess.GetComponent<Jess>().animator.SetBool("isStand", true);
        bfq.numOfDialogueWithKris = 5;
    }
}
