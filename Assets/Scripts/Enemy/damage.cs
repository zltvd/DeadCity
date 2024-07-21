using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int damageCount;
    public GG gG;

    private void OnCollisionEnter(Collision collision)
    {
        gG.TakeDamage(damageCount);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        print("ddd");
    }
}
