using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steve : MonoBehaviour, IDataPersistence
{
    Quaternion camRot;
    public Animator animator;
    public void LoadData(GameData data)
    {
        this.transform.position = data.StevePosition;

        camRot.eulerAngles = data.SteveRotation;
        this.transform.rotation = camRot;
    }
    public void SaveData(GameData data)
    {
        data.StevePosition = this.transform.position;

        data.SteveRotation = this.transform.rotation.eulerAngles;
    }
}
