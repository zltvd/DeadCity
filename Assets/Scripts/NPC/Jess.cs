using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jess : MonoBehaviour, IDataPersistence
{
    public Animator animator;
    Quaternion camRot;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.JessPosition;

        camRot.eulerAngles = data.JessRotation;
        this.transform.rotation = camRot;
    }
    public void SaveData(GameData data)
    {
        data.JessPosition = this.transform.position;

        data.JessRotation = this.transform.rotation.eulerAngles;
    }
}
