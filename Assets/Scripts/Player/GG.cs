using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System;
using UnityEditor;
using Unity.VisualScripting;
using Unity.Collections.LowLevel.Unsafe;

public class GG : MonoBehaviour, IDataPersistence
{
    [Range(50f, 200f)]
    public float walkSpeed = 100f;
    [Range(100f, 500f)]
    public float runSpeed = 350f;
    [Range(1000f, 2000f)]
    public float jumpForse = 1000f;
    public LayerMask ground;
    public Transform groundDetector;
    private float mSpeed;
    public Camera cam;
    float baseFOV = 60f;
    [HideInInspector] public float sprintFOV = 1.25f;
    Rigidbody rb;
    public GameObject panel;
    public GameObject panelTarhet;
    public Stats stats = new Stats();
    public TMP_Text descr;
    public float interaction_range = 5;
    public LayerMask items;
    public LayerMask chest;
    public InventoryUI invui;
    public bool isOpened;
    public bool isGameOver;
    public TextMeshProUGUI playerHPText;
    public float patrons;
    public int maxPatrons;
    [HideInInspector] private int maxHealth;
    public int currentHealth = 100;
    public HealthBar healthBar;
    public TextMeshProUGUI bullet;
    [HideInInspector] public bool isUse = false;
    public PostProcessVolume Blur;
    public Animator animator;
    public GameObject panelLose;
    public LayerMask npc;
    [HideInInspector] public bool isDialogue;
    public GameObject GG_player;
    public GameObject Map;
    [HideInInspector] public bool isCanMap;
    public GameObject shopPanel;
    public TMP_Text coinsText;
    public TMP_Text coinsCanvasText;
    public int coins = 0;
    public BaseForQuests bfq;
    public GrenadeThrow gnd;
    public bool isEndGameActive;

    Quaternion camRot;

    private Outline lastOutlinedObj;
    public GameObject settingsPanel;

    AudioSource audioSource;
    public AudioClip potionAudio;
    public AudioClip chekaAudio;
    public AudioClip winAudio;
    public AudioClip loseAudio;

    private bool isFirstWasShowed = false;
    private bool isInvWasntEmpty;
    public bool isGameOveeer;
    void Start()
    {
        if (isCanMap == true)
        {
            bfq.cam_forBigMap.enabled = true;
            System.Threading.Thread.Sleep(1000);
            bfq.cam_forBigMap.enabled = false;

        }
        audioSource = gameObject.GetComponent<AudioSource>();
        mSpeed = walkSpeed;
        rb = GetComponent<Rigidbody>();
        maxHealth = stats.health;
        healthBar.SetSliderMax(maxHealth);
        isGameOver = false;
        //maxPatrons = stats.bull;
        Blur = Camera.main.gameObject.GetComponent<PostProcessVolume>();
        coinsText.text = coins.ToString();
        coinsCanvasText.text = coins.ToString();

        float volume = settingsPanel.GetComponentInChildren<Volume>().sliderMusic.value;
        settingsPanel.GetComponentInChildren<Volume>().mixer.SetFloat(settingsPanel.GetComponentInChildren<Volume>().wichGroup, Mathf.Log10(volume) * 20);
        bfq.cam_forBigMap.enabled = false;

    }
    private void Update()
    {
        healthBar.SetSlider(currentHealth);
        if (bfq.isGameOver == true)
        {
            bfq.winPanel.SetActive(true);
            panelTarhet.SetActive(false);
            bfq.invToHide.SetActive(false);
            Time.timeScale = 0f;
            Blur.enabled = true;
            audioSource.PlayOneShot(winAudio);
            bfq.isGameOver = false;
            isGameOveeer = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && isEndGameActive == false)
        {
            use(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && isEndGameActive == false)
        {
            use(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && isEndGameActive == false)
        {
            use(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && isEndGameActive == false)
        {
            use(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && isEndGameActive == false)
        {
            use(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && isEndGameActive == false)
        {
            use(5);
        }

        coinsText.text = coins.ToString();
        coinsCanvasText.text = coins.ToString();
        if (Input.GetKeyDown(KeyCode.P) && isEndGameActive == false)
        {
            panel.SetActive(true);
            panelTarhet.SetActive(false);
            bfq.invToHide.SetActive(false);
            Time.timeScale = 0f;
            Blur.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.M) && isEndGameActive == false)
        {
            if (isCanMap == true)
            {
                bfq.cam_forBigMap.enabled = true;
                Map.SetActive(true);
                panelTarhet.SetActive(false);
                Time.timeScale = 0f;
                Blur.enabled = true;
                bfq.invToHide.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && bfq.cam_FPS.enabled == true && isEndGameActive == false)
        {
            bfq.cam_forBigMap.enabled = false;
            settingsPanel.SetActive(false);
            bfq.elsePartsOfGun.SetActive(true);
            bfq.camer.cursCanMove = true;
            animator.SetTrigger("Normal");
            Time.timeScale = 1f;
            invui.hideChestMenu();
            panel.SetActive(false);
            Map.SetActive(false);
            shopPanel.SetActive(false);
            panelTarhet.SetActive(true);
            isOpened = false;
            Blur.enabled = false;
            bfq.invToHide.SetActive(true);
            bfq.cam_FPS.enabled = true;
            bfq.prizel.SetActive(true);
            bfq.gunRender.enabled = true;
            bfq.gun.mew = true;
            if (bfq.isEscActive == true)
            {
                bfq.Map.SetActive(true);
                bfq.questPanel.SetActive(true);

            }
        }
        playerHPText.text = "" + currentHealth;
        bullet.text = patrons + "/" + maxPatrons;
        if (isGameOver == true)
        {
            panelLose.SetActive(true);
            bfq.invToHide.SetActive(false);
            audioSource.PlayOneShot(loseAudio);
            panelTarhet.SetActive(false);
            Time.timeScale = 0f;
            Blur.enabled = true;
            isGameOver = false;
            isEndGameActive = true;
            bfq.sliderBossHP.SetActive(false);
}
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (isDialogue == true)
        {
            rb.freezeRotation = true;
            rb.isKinematic = true;
            panelTarhet.SetActive(false);
        }
        if (isDialogue == false && Blur.enabled == false)
        {
            rb.isKinematic = false;
            panelTarhet.SetActive(true);
        }
    }
    public void Restart(int next)
    {
        Global.nxtLVL = next;
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void Strike()
    {
        patrons--;
    }
    void FixedUpdate()
    {
        bool GroundCheck = Physics.Raycast(groundDetector.position, Vector3.down, 0.1f, ground);
        bool jump = Input.GetKey(KeyCode.Space) && GroundCheck;
        if (jump == true) rb.AddForce(Vector3.up * jumpForse);
        bool sprint = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        float xMove = Input.GetAxisRaw("Horizontal");
        float zMove = Input.GetAxisRaw("Vertical");
        if (sprint == true && zMove > 0)
        {
            mSpeed = runSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV * sprintFOV, Time.fixedDeltaTime * 8f);
        }
        else
        {
            mSpeed = walkSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, baseFOV, Time.fixedDeltaTime * 8f);
        }
            Vector3 dir = new Vector3(xMove, 0, zMove);
        dir.Normalize();
        Vector3 v = transform.TransformDirection(dir) * mSpeed * Time.fixedDeltaTime;
        v.y = rb.velocity.y;
        rb.velocity = v;
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, interaction_range, items))
        {
            if (hit.transform.gameObject.CompareTag("Health"))
            {
                if (lastOutlinedObj != null)
                    lastOutlinedObj.enabled = false;

                lastOutlinedObj = hit.transform.gameObject.GetComponent<Outline>();
                lastOutlinedObj.enabled = true;
            }
            else if (lastOutlinedObj != null)
            {
                lastOutlinedObj.enabled = false;
                lastOutlinedObj = null;
            }
        }
        else
            descr.text = "";
        if (Physics.Raycast(ray, out hit, interaction_range, chest))
        {
            descr.text = "Chest";
            if (Input.GetKeyDown(KeyCode.E))
            {
                Time.timeScale = 0f;
                hit.transform.GetComponent<CheastInventory>().playInv = GetComponent<Inventory>();
                Debug.Log(GetComponent<Inventory>());
                invui.showChestMenu();
                isOpened = true;
                Blur.enabled = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1f;
            invui.hideChestMenu();
            isOpened = false;
            Blur.enabled = false;
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
        if (currentHealth <= 0)
        {
            panelLose.SetActive(true);
            panelTarhet.SetActive(false);
            Time.timeScale = 0f;
            Blur.enabled = true;
            isEndGameActive = true;
            bfq.invToHide.SetActive(false);
            bfq.sliderBossHP.SetActive(false);
        }
    }
    public void Heal()
    { 
        currentHealth += 5;
        healthBar.SetSlider(currentHealth);
    }
    public void use(int i)
    {
        ItemInstance item = GetComponent<Inventory>().GetItem(i);
        if (item == null) return;
        if (GetComponent<Inventory>().GetItem(i).itemDecrs.type == item_type.bullet && bfq.gun.mew == true)
        {
            while (item.amount > 0 && patrons < maxPatrons)
            {
                if (item.use(this))
                {
                    GetComponent<Inventory>().removeItem(i);
                    isUse = true;
                }
            }
        }
        else if (GetComponent<Inventory>().GetItem(i).itemDecrs.type == item_type.potion || GetComponent<Inventory>().GetItem(i).itemDecrs.type == item_type.bigpotion)
        {
            if (currentHealth < maxHealth)
            {
                if (item.use(this))
                {
                    audioSource.PlayOneShot(potionAudio);
                    GetComponent<Inventory>().removeItem(i);
                    healthBar.SetSlider(currentHealth);
                }
            }
        }
        else if (GetComponent<Inventory>().GetItem(i).itemDecrs.type == item_type.grenade)
        {
            if (item.use(this))
            {
                audioSource.PlayOneShot(chekaAudio);
                GetComponent<Inventory>().removeItem(i);
            }
        }
        else return;
    }
    public void drop(int i)
    {
        ItemInstance item = GetComponent<Inventory>().GetItem(i);
        if (item == null) return;
        GetComponent<Inventory>().dropItem(i);
    }
    public void destroy(int i)
    {
        ItemInstance item = GetComponent<Inventory>().GetItem(i);
        if (item == null) return;
        GetComponent<Inventory>().destroyItem(i);
    }
    public void pass(int i)
    {
        ItemInstance item = GetComponent<Inventory>().GetItem(i);
        if (item == null) return;
        if (isOpened == true)
            GetComponent<Inventory>().passItem(i);
    }
    public void sell(int i)
    {
        ItemInstance item = GetComponent<Inventory>().GetItem(i);
        if (item == null) return;
        GetComponent<Inventory>().sellItem(i);
    }
    public void LoadData(GameData data)
    {
        this.patrons = data.patronsCount;
        this.transform.position = data.playerPosition;
        this.currentHealth = data.ggHP;
        healthBar.SetSlider(currentHealth);
        this.coins = data.currentCoins;
        this.isCanMap = data.isCanMap;
        if (isCanMap == true)
        {
            bfq.cam_forBigMap.enabled = true;
        }
        this.isFirstWasShowed = data.isFirstWasShowed;
        if (isFirstWasShowed == false)
        {
            bfq.tutorialsImg[0].SetActive(true);
            isFirstWasShowed = true;
        }

        camRot.eulerAngles = data.camOfPlayerRotation;
        this.transform.rotation = camRot;

        this.isInvWasntEmpty = data.isInvWasntEmpty;
        if (this.isInvWasntEmpty == true)
        {
            bfq.playInv.removeItemsFromSlot(5);
            bfq.playInv.removeItemsFromSlot(4);
            bfq.playInv.removeItemsFromSlot(3);
            bfq.playInv.removeItemsFromSlot(2);
            bfq.playInv.removeItemsFromSlot(1);
            bfq.playInv.removeItemsFromSlot(0);
        }
        for (int i = 0; i < data.itemNamesGGInv.Length; i++)
        {
            if (this.isInvWasntEmpty == true)
            {
                if (data.itemNamesGGInv[i].Trim().Length != 0)
                {
                    Item item = Resources.Load<Item>($"ScrObjects/{data.itemNamesGGInv[i]}");
                    InventorySlot newItem = new InventorySlot(new ItemInstance());
                    newItem.item.itemDecrs = item;
                    newItem.item.amount = data.itemAmountsGGInv[i];
                    //bfq.playInv.items.Add(newItem);
                    bfq.playInv.addItems(newItem.item);
                    bfq.playInv.OnInventoryChanged.Invoke();
                }
            }
            
        }
        if (isCanMap == true)
        {
            bfq.cam_forBigMap.enabled = false;
        }
        this.isGameOveeer = data.isGameOver;
        if (isGameOveeer == true)
        {
            bfq.Lidia.SetActive(false);
            bfq.Kris.SetActive(false);
            bfq.Jess.SetActive(false);
            bfq.Steve.SetActive(false);
            Destroy(bfq.questPanel);
        }
        this.maxPatrons = data.maxPatronsGG;
    }
    public void SaveData(GameData data)
    {
        data.patronsCount = this.patrons;
        data.playerPosition = this.transform.position;
        data.saveTime = DateTime.Now.ToString("HH:mm");
        data.saveDate = DateTime.Now.ToString("dd.MM.yyyy");
        data.ggHP = this.currentHealth;
        data.currentCoins = this.coins;
        data.isFirstWasShowed = this.isFirstWasShowed;

        data.isCanMap = this.isCanMap;

        data.camOfPlayerRotation = this.transform.rotation.eulerAngles;

        data.itemNamesGGInv = new string[bfq.playInv.items.Count];
        data.itemAmountsGGInv = new int[bfq.playInv.items.Count];

        for (int i = 0; i < bfq.playInv.items.Count; i++)
        {
            if (bfq.playInv.items[i].item != null)
            {
                data.isInvWasntEmpty = true;
                data.itemNamesGGInv[i] = bfq.playInv.GetItem(i).itemDecrs.itemName;
                data.itemAmountsGGInv[i] = bfq.playInv.GetItem(i).amount;
            }

        }
        data.isGameOver = this.isGameOveeer;
        data.maxPatronsGG = this.maxPatrons;
    }
}
