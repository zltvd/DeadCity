using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ndFloorOut : MonoBehaviour, IInteractable
{
    [SerializeField] private string promt;
    public Black_Screen_Fade fade;
    public GameObject player;
    public BaseForQuests bfq;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        fade.x_p = 25.9f;
        fade.y_p = 1.06f;
        fade.z_p = 26f;

        fade.X_R = -0.1f;
        fade.Y_R = -491f;
        fade.Z_R = 0.82f;

        bfq.fade_screen.fade_enabled = true;
        return true;
    }
}
