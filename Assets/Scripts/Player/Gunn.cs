using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Gunn : MonoBehaviour, IDataPersistence
{
    [HideInInspector] public float fireRate = 10f;
    [HideInInspector] public float nextShot = 0f;
    [HideInInspector] public float valShot = 0;
    public float patrons;
    [HideInInspector] public float gilzaForce;
    [HideInInspector] public float smth;

    [HideInInspector] public float curLvlForce =  1;
    [HideInInspector] public float curLvlPat = 1;
    [HideInInspector] public float nxtPat;
    [HideInInspector] public float nxtForce;
    [HideInInspector] public float nf;
    [HideInInspector] public float np;
    [HideInInspector] public int coastPatr;

    public bool isGunActive;
    public bool mew = false;

    public int damageAmount;
    [HideInInspector] public int coastForce;
    [HideInInspector] public int nFt;
    [HideInInspector] public int nPt;

    public ParticleSystem flash;
    public ParticleSystem onhit;

    public Transform fp;
    public Transform tochka;

    public AudioClip clip;
    public AudioClip cli;
    public AudioSource audioSource;

    public Text val;
    public Text txt;

    public TMP_Text toNextLvl;
    public TMP_Text toNextLvlPat;
    public TMP_Text curForce;
    public TMP_Text nForce;
    public TMP_Text curPatr;
    public TMP_Text nPatr;
    public TMP_Text coastTextForce;
    public TMP_Text coastTextPatr;

    public GameObject Pistol;
    public GameObject gilza;
    public Rigidbody rigGilza;
    
    public Stats stats = new Stats();
    public GG gG;
    public BaseForQuests bfq;
    public float zombiesLeft = 7;
    public Animator animator;

    public bool isSimpleZombiesDead;
    public bool canShoot;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        txt.text = valShot.ToString();
        patrons = gG.patrons;
        //isGunActive = false;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (bfq.Kris.GetComponent<NPC>().isGoToZombie == true)
        {
            if (zombiesLeft > 0)
            {
                bfq.goal.text = "Осталось зомби: " + zombiesLeft;
            }
            if (zombiesLeft <= 0)
            {
                bfq.goal.text = "Вернитесь к ребятам";
                bfq.Kris.GetComponent<NPC>().isGoToZombie = false;
                bfq.numOfDialogueWithKris = 7;
                bfq.Jess.transform.eulerAngles = new Vector3(0f, 265f, 0f);
                bfq.Kris.transform.eulerAngles = new Vector3(0f, 265f, 0f);
            }
        }


        if (bfq.zombies[0].GetComponentInChildren<enemyscr>().hp <= 0 && bfq.zombies[1].GetComponentInChildren<enemyscr>().hp <= 0 && bfq.numOfDialogueWithKris == 1)
        {
            bfq.goal.text = "Вернитесь к Крису";
            bfq.smallAreaForQuest.SetActive(false);
            bfq.bigAreaForQuest.SetActive(false);
            isSimpleZombiesDead = true;
            bfq.numOfDialogueWithKris = 2;
            
        }
        nf = curLvlForce + 1;
        np = curLvlPat + 1;

        nFt = damageAmount + 5;
        nPt = gG.maxPatrons + 2;

        toNextLvl.text = "Ур. " + curLvlForce + "       " + " ->  Ур. " + nf;
        toNextLvlPat.text = "Ур. " + curLvlPat +  "       " + " ->  Ур. " + np;

        curForce.text = damageAmount.ToString();
        nForce.text = nFt.ToString();

        curPatr.text = gG.maxPatrons.ToString();
        nPatr.text = nPt.ToString();

        coastForce = damageAmount * 10;
        coastTextForce.text = coastForce.ToString();

        coastPatr = gG.maxPatrons * 15;
        coastTextPatr.text = coastPatr.ToString();

        if (curLvlForce == 8)
        {
            toNextLvl.text = "Ур. " + curLvlForce + "         максимум";
            nForce.text = null;
            coastTextForce.text = null;
        }

        if (curLvlPat == 5)
        {
            toNextLvlPat.text = "Ур. " + curLvlPat + "         максимум";
            nPatr.text = null;
            coastTextPatr.text = null;
        }

        if (isGunActive == false)
        {
            gameObject.SetActive(false);
        }
        if (isGunActive == true)
        {
            gameObject.SetActive(true);
        }
        patrons = stats.bull;
        if (Input.GetMouseButtonDown(0) == true && Time.time >= nextShot && gG.patrons > 0 && mew == true && bfq.gg.cam.enabled == true && canShoot == true)
        {
            nextShot = Time.time + 1 / fireRate;
            Shoot();
        }
        if (gG.isUse == true && mew == true)
        {
            Pistol.GetComponent<Animator>().SetTrigger("Reload");
            audioSource.PlayOneShot(cli);
            valShot = 0;
            gG.isUse = false;
        }
        smth = 25 - valShot;
        txt.text = smth.ToString();
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (mew == true)
            {
                bfq.gunRender.enabled = false;
                bfq.elsePartsOfGun.SetActive(false);
                bfq.prizel.SetActive(false);
                mew = false;
            }
            else if (mew == false)
            {
                bfq.gunRender.enabled = true;
                bfq.elsePartsOfGun.SetActive(true);
                bfq.prizel.SetActive(true);
                mew = true;
            }
        }    
        
    }
    public void reload_start()
    {
        canShoot = false;
    }
    public void reload_finish()
    {
        canShoot = true;
    }
    public void LvlForce()
    {
        if (curLvlForce < 8)
        {
            if (gG.coins >= coastForce)
            {
                curLvlForce = nf;
                damageAmount = nFt;
                gG.coins = gG.coins - coastForce;
            }
        }
    }
    public void LvlPatr()
    {
        if (curLvlPat < 5)
        {
            if (gG.coins >= coastPatr)
            {
                curLvlPat = np;
                gG.maxPatrons = nPt;
                gG.coins = gG.coins - coastPatr;
            }
        }
    }
    void Shoot()
    {
        Debug.DrawRay(fp.position, fp.forward, Color.green);
        RaycastHit hit;
            if (Physics.Raycast(fp.position, fp.forward, out hit, Score.range))
            {
                gG.Strike();
                Debug.DrawRay(fp.position, fp.forward, Color.green);

                if (hit.transform.CompareTag("Boss"))
                {
                    Boss_Zombie t = hit.transform.GetComponent<Boss_Zombie>();
                    t.Death(damageAmount);
                }

                if (hit.transform.CompareTag("Enemy"))
                {
                enemyscr t = hit.transform.GetComponent<enemyscr>();
                    t.Death(damageAmount);
                 }
                if (Score.range == 10)
                {
                    flash.Play();
                    valShot += 1;
                    ParticleSystem hitEffects = Instantiate(onhit, hit.point, Quaternion.LookRotation(hit.normal));
                    hitEffects.Play();
                    Pistol.GetComponent<Animator>().SetTrigger("Shoot");
                    audioSource.PlayOneShot(clip);
                    Destroy(hitEffects.gameObject, 1f);
                    GameObject gil = Instantiate(gilza, tochka.position, Quaternion.identity);
                    rigGilza = gil.GetComponent<Rigidbody>();
                    rigGilza.AddForce(Vector3.Cross(transform.up, transform.right) * gilzaForce);
                    Destroy(gil.gameObject, 3f);
                }
            }
    }

    public void LoadData(GameData data)
    {
        this.isGunActive = data.isGunCanBeActivate;

        if (isGunActive)
        {
            bfq.gunn.SetActive(true);
            bfq.gunned.SetActive(true);
            bfq.gun.mew = true;
        }

        this.isSimpleZombiesDead = data.isSimpleZombieDead;
        this.curLvlForce = data.currentLvlOfForce;
        this.curLvlPat = data.currentLvlOfPatrons;
        this.canShoot = data.isCanShoot;
        this.zombiesLeft = data.killedZombie;
        if (zombiesLeft <= 0)
        {
            Destroy(GameObject.Find("Dialogue with Jess and Steve"));
        }
        this.damageAmount = data.damageAmount;
    }
    public void SaveData(GameData data)
    {
        data.isGunCanBeActivate = this.isGunActive;
        data.isSimpleZombieDead = this.isSimpleZombiesDead;
        data.currentLvlOfForce = this.curLvlForce;
        data.currentLvlOfPatrons = this.curLvlPat;
        data.isCanShoot = this.canShoot;
        data.killedZombie = this.zombiesLeft;
        data.damageAmount = this.damageAmount;
    }
}
