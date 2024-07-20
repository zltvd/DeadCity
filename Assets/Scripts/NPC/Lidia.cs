using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lidia : MonoBehaviour, IDataPersistence
{
    public BaseForQuests bfq;
    public Animator animator;
    Quaternion camRot;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (bfq.isWave == true)
        {
            animator.SetBool("isWaving", true);
            bfq.isWave = false;
        }
        if (bfq.isMove == true)
        {
            animator.SetBool("isWaving", false);
            animator.Play("talking");
            bfq.isMove = false;
        }
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.LidiaPosition;

        camRot.eulerAngles = data.LidiaRotation;
        this.transform.rotation = camRot;
    }
    public void SaveData(GameData data)
    {
        data.LidiaPosition = this.transform.position;

        data.LidiaRotation = this.transform.rotation.eulerAngles;
    }
}
