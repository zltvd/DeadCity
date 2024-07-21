using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShelterOut : MonoBehaviour, IInteractable
{
    [SerializeField] private string promt;
    public GameObject player;
    public Black_Screen_Fade fade;
    public BaseForQuests bfq;
    public string InteractionPromt => promt;
    public bool Interact(Interact interactor)
    {
        if (bfq.isOutUnlock == true)
        {
            fade.x_p = 23.1f;
            fade.y_p = 0.94f;
            fade.z_p = 32.2f;

            fade.X_R = 0f;
            fade.Y_R = -368.7f;
            fade.Z_R = 0f;

            bfq.fade_screen.fade_enabled = true;
        }
        for (int i = 0; i < 22; i++)
        {
            bfq.zombies[i].GetComponent<AudioSource>().enabled = true;

        }
        if (bfq.numOfDialogueWithKris == 9)
        {
            bfq.Robert.transform.position = new Vector3(-18.23f, -0.037f, 35f);
            bfq.Robert.transform.eulerAngles = new Vector3(0f, 47f, 0f);

            bfq.Kris.GetComponent<NavMeshAgent>().enabled = false;
            bfq.Kris.transform.position = new Vector3(-18.49f, -0.013f, 36.05f);
            bfq.Kris.transform.eulerAngles = new Vector3(0f, -246.5f, 0f);

            bfq.zombies[9].SetActive(true);

            bfq.goal.text = "Найдите Криса и Роберта неподалеку";

            bfq.numOfDialogueWithKris = 10;
        }
        return true;
    }
}
