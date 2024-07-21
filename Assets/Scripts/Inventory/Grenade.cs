using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    public GameObject explosionEffect;
    float countdown;
    bool hasExploded = false;
    public AudioSource audioSource;
    public AudioClip explosionSound;
    void Start()
    {
        countdown = delay;
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasExploded)
        {
            audioSource.PlayOneShot(explosionSound);
            Explode();
            hasExploded = true;
        }
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        audioSource.PlayOneShot(explosionSound);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider nearbyObjects in colliders)
        {
            Rigidbody rb = nearbyObjects.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, transform.position, radius);
            }
            enemyscr en = nearbyObjects.GetComponent<enemyscr>();
            if (en != null)
            {
                en.Death(250);
            }
            Boss_Zombie boss = nearbyObjects.GetComponent<Boss_Zombie>();
            if (boss != null)
            {
                boss.Death(250);
            }
        }
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject, explosionSound.length);
    }
}
