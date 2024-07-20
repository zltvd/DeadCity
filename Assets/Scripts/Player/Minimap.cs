using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour, IDataPersistence
{
    public GameObject player;
    private Vector3 offset;
    Rigidbody rb;
    Quaternion camRot;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
    public void LoadData(GameData data)
    {
        this.transform.position = data.minimapPosition;

        camRot.eulerAngles = data.minimapRotation;
        this.transform.rotation = camRot;
    }
    public void SaveData(GameData data)
    {
        data.minimapPosition = this.transform.position;

        data.minimapRotation = this.transform.rotation.eulerAngles;
    }
}
