using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Boss_Zombie : MonoBehaviour //скрипт босса-зомби
{
    [HideInInspector] public GameObject player;
    [HideInInspector] public GG gG;
    [HideInInspector] public BaseForQuests bfq;
    public GameObject weapon;

    Animator animator;
    [HideInInspector] public BoxCollider boxCollider;
    //Rigidbody rb;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 DestPoint;

    bool playerInSight, playerinAttackRange;
    bool WalkpointSet;

    [SerializeField] float range;
    [SerializeField] float sightRange, attackRange;
    public float hp = 100;
    public float forwhichquest;

    public int coastFromDeath;
    public int damageCount;

    [HideInInspector] public Slider healthBar;

    public AudioClip idle;
    public AudioClip attack;
    public AudioClip death;
    AudioSource audioSource;
    [HideInInspector] public float idleTime;
    [HideInInspector] public float attackTime;
    public float timerIdle;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        agent.updatePosition = true;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        healthBar.value = hp;

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
        agent.speed = 1.5f;
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
            audioSource.PlayOneShot(attack);
            attackTime = 0;
        }
    }
    public void Death(int damageCount)
    {
        hp -= damageCount;
        if (hp <= 0)
        {
            gG.coins = gG.coins + coastFromDeath;
            bfq.aboutPlusCoins.SetActive(true);
            bfq.plusMoney.text = "+ " + coastFromDeath;
            audioSource.PlayOneShot(death);
            animator.SetTrigger("Death");
            GetComponent<Collider>().enabled = false;
            healthBar.gameObject.SetActive(false);
            Destroy(weapon);
            agent.speed = 0f;
            bfq.gun.zombiesLeft = bfq.gun.zombiesLeft - forwhichquest;
            bfq.goal.text = "Поговорите с ребятами";
            Destroy(bfq.areaBoss);
            bfq.sliderBossHP.SetActive(false);

            bfq.numOfDialogueWithKris = 11;

            bfq.Kris.GetComponent<NavMeshAgent>().enabled = false;
            bfq.Kris.transform.position = new Vector3(-36.4f, -0.011f, 11.24f);
            bfq.Kris.transform.eulerAngles = new Vector3(0f, -168.3f, 0f);

            bfq.Robert.transform.position = new Vector3(-35.2f, -0.03f, 10.69f);
            bfq.Robert.transform.eulerAngles = new Vector3(0f, -131.4f, 0f);
        }
    }
    public void Patrol()
    {
        animator.SetBool("isChase", false);
        if (idleTime > timerIdle)
        {
            audioSource.PlayOneShot(idle);
            idleTime = 0;
        }
        agent.speed = 0.01f;
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
        var player = other.GetComponent<GG>();
        if (player != null)
        {
            gG.TakeDamage(damageCount);
        }
    }
}
