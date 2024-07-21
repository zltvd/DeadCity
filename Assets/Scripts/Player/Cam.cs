using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cam : MonoBehaviour
{
    public static bool cursorLock = false;
    public Transform player;
    public Transform cam;
    public float xSens = 100f;
    public float ySens = 100f;
    Quaternion center;
    public bool cursCanMove = true;
    public BaseForQuests bfq;
    public Slider horizontalValue;
    public Slider verticalValue;
    void Start()
    {
        center = cam.localRotation;
    }
    void Update()
    {
        xSens = horizontalValue.value;
        ySens = verticalValue.value;
        if (cursCanMove == true)
        {
            float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
            Quaternion yRot = cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);
            if (Quaternion.Angle(center, yRot) < 45f)
                cam.localRotation = yRot;
            float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
            Quaternion xRot = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);
            player.localRotation = xRot;
        }
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (bfq.gun.isGunActive == true)
            {
                bfq.gun.mew = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
                cursorLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            bfq.gun.mew = false;
            if (Input.GetKeyDown(KeyCode.LeftControl))
                cursorLock = true;
        }
    }
}
