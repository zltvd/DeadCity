using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.VFX;

public class enemyscr : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid for if")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    public GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    Vector3 DestPoint;
    bool WalkpointSet;
    [SerializeField] float range;

    [SerializeField] float sightRange, attackRange;
    bool playerInSight, playerinAttackRange;
    Animator animator;

    public float hp = 100;
    public Slider healthBar;
    public GameObject weapon;
    public AudioClip[] idle;
    public AudioClip[] attack;
    public AudioClip death;
    AudioSource audioSource;

    public BoxCollider boxCollider;
    Rigidbody rb;
    public GG gG;
    public int coastFromDeath;
    public BaseForQuests bfq;
    public int damageCount;

    public float timerIdle;
    public float idleTime;
    public float attackTime;

    public float forwhichquest;

    private Vector3 alliveZombiePosition;
    private float zombieHP;
    [SerializeField] private bool died = false;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerinAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (!playerInSight && !playerinAttackRange && hp > 0) Patrol();
        if (playerInSight && !playerinAttackRange && hp > 0) Chase();
        if (playerInSight && playerinAttackRange && hp > 0) Attack();

        idleTime += Time.deltaTime;
        attackTime += Time.deltaTime;


    }
    public void Chase()
    {
        
        agent.SetDestination(player.transform.position);
        agent.speed = 3;
        animator.SetBool("isChase", true);
    }
    public void Attack()
    {
        animator.SetBool("isChase", false);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            animator.SetTrigger("Attack");
            agent.SetDestination(transform.position);
        }
        if (attackTime > 4)
        {
            attackSounds();
            attackTime = 0;
        }
    }
    public void Death(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            if (bfq.Kris.GetComponent<NPC>().isGoToZombie == true)
            {
                bfq.gun.zombiesLeft -= forwhichquest;
            }
            gG.coins = gG.coins + coastFromDeath;
            bfq.aboutPlusCoins.SetActive(true);
            bfq.plusMoney.text = "+ " + coastFromDeath;
            animator.SetTrigger("Death");
            audioSource.PlayOneShot(death);
            GetComponent<Collider>().enabled = false;
            Destroy(weapon);
            agent.speed = 0f;
            died = true;
        }
    }
    public void Patrol()
    {
        animator.SetBool("isChase", false);
        if (idleTime > timerIdle)
        {
            idleSounds();
        }
        agent.speed = 0.2f;
        if (!WalkpointSet) SearchForDest();
        if (WalkpointSet) agent.SetDestination(DestPoint);
        if (Vector3.Distance(transform.position, DestPoint) < 10) WalkpointSet = false;
    }
    public void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);

        DestPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(DestPoint, Vector3.down, groundLayer))
        {
            WalkpointSet = true;
        }
    }
    public void EnableAttack()
    {
        boxCollider.enabled = true;
    }
    public void DisableAttack()
    {
        boxCollider.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        gG.TakeDamage(damageCount);
    }
    void idleSounds()
    {
        AudioClip idleAudio = idle[Random.Range(0, idle.Length)];
        audioSource.PlayOneShot(idleAudio);
        idleTime = 0;
    }

    void attackSounds()
    {
        AudioClip attackAudio = attack[UnityEngine.Random.Range(0, attack.Length)];
        audioSource.PlayOneShot(attackAudio);
    }
    public void LoadData(GameData data)
    {
        data.activeZombiesPosition.TryGetValue(id, out alliveZombiePosition);
        if (alliveZombiePosition != Vector3.zero)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.transform.position = alliveZombiePosition;
            this.GetComponent<NavMeshAgent>().enabled = true;
        }
        data.activeZombiesHP.TryGetValue(id, out zombieHP);
        if (bfq.isMapAndQuestAreActive == true)
        {
            this.hp = zombieHP;
        }
        //if (zombieHP > 0)
        //{
        //    this.hp = zombieHP;
        //}

        data.diedZombies.TryGetValue(id, out died);
        if (died)
        {
            gameObject.SetActive(false);
        }
    }
    public void SaveData(GameData data)
    {
        if(data.activeZombiesPosition.ContainsKey(id))
        {
            data.activeZombiesPosition.Remove(id);
        }
        data.activeZombiesPosition.Add(id, this.transform.position);


        if (data.activeZombiesHP.ContainsKey(id))
        {
            data.activeZombiesHP.Remove(id);
        }
        data.activeZombiesHP.Add(id, this.hp);
        

        if (data.diedZombies.ContainsKey(id))
        {
            data.diedZombies.Remove(id);
        }
        data.diedZombies.Add(id, died);

    }
}
