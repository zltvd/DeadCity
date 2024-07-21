using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_DWY : MonoBehaviour
{
    public float startTime = 0;
    public float endTime;
    public BaseForQuests bfq;
    private void Start()
    {
        startTime = 0;
    }
    void FixedUpdate()
    {
        startTime += 0.1f * Time.deltaTime;
        if (startTime >= endTime)
        {
            gameObject.SetActive(false);
            startTime = 0;
        }
    }
}
