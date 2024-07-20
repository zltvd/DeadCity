using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondFloor : MonoBehaviour, IInteractable
{
    [SerializeField] private string promt;
    public Black_Screen_Fade fade;
    public GameObject player;
    public BaseForQuests bfq;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        if (bfq.is2ndFloorUnlock == true)
        {
            fade.x_p = 26.819f;
            fade.y_p = 4.997f;
            fade.z_p = 22.582f;

            fade.X_R = 0.245f;
            fade.Y_R = -417.3f;
            fade.Z_R = -0.173f;

            bfq.fade_screen.fade_enabled = true;
        }
        return true;
    }
}
