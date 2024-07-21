using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class NumOfTrigger : MonoBehaviour
{
    public float numOfTr;
    public string text_DWY;
    public BaseForQuests bfq; 
    private void Start()
    {
        bfq.cam_forDialogue.enabled = false;
        bfq.cam_FPS.enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (numOfTr == 1)
            {
                bfq.isWave = true;
            }
            if (numOfTr == 2)
            {
                bfq.Lidia.SetActive(false);
            }
            if (numOfTr == 3)
            {
                bfq.gun.mew = false;
                bfq.Lidia.GetComponent<NPC>().interact(0);
                bfq.camer.cursCanMove = false;
                bfq.isMove = true;
                bfq.cam_forDialogue.enabled = true;
                bfq.cam_FPS.enabled = false;
                bfq.gg.isDialogue = true;
                bfq.toHide.SetActive(false);
                bfq.invToHide.SetActive(false);
                bfq.quest.text = "С чистого листа";
                bfq.goal.text = "Найдите убежище";
                bfq.cam_forBigMap.enabled = true;
            }
            if (numOfTr == 4)
            {
                bfq.DWY.GetComponent<Delete_DWY>().startTime = 0;
                bfq.dwy.text = "Голова раскалывается…";
                bfq.DWY.SetActive(true);
                Destroy(this.gameObject);
            }
            if (numOfTr == 5)
            {
                bfq.DWY.GetComponent<Delete_DWY>().startTime = 0;
                bfq.dwy.text = "Где я вообще? Не могу ничего вспомнить";
                bfq.DWY.SetActive(true);
                Destroy(this.gameObject);
            }
            if (numOfTr == 6)
            {
                bfq.DWY.GetComponent<Delete_DWY>().startTime = 0;
                bfq.dwy.text = "Кажется, впереди кто-то есть, нужно узнать что происходит";
                bfq.DWY.SetActive(true);
                Destroy(this.gameObject);
            }
            if (numOfTr == 7)
            {
                bfq.DWY.GetComponent<Delete_DWY>().startTime = 0;
                bfq.dwy.text = "Убежище должно быть уже близко";
                bfq.DWY.SetActive(true);
                Destroy(this.gameObject);
            }
            if (numOfTr == 8)
            {
                bfq.DWY.GetComponent<Delete_DWY>().startTime = 0;
                bfq.dwy.text = "Какого… что это за твари такие?";
                bfq.DWY.SetActive(true);
                Destroy(this.gameObject);
            }
            if (numOfTr == 9)
            {
                bfq.Kris.GetComponent<NavMeshAgent>().enabled = false;
                bfq.Kris.transform.position = new Vector3(28.3f, -0.004f, -53.3f);
                bfq.Kris.transform.eulerAngles = new Vector3(-0.3f, 38.7f, -0.002f);
                bfq.Kris.GetComponent<NavMeshAgent>().enabled = true;
                this.gameObject.GetComponent<SphereCollider>().enabled = false;
                bfq.numOfDialogueWithKris = 4;
            }
            if (numOfTr == 12 && bfq.isStop == true)
            {
                bfq.gun.mew = false;
                bfq.Kris.GetComponent<NPC>().interact(5);
                bfq.camer.cursCanMove = false;
                bfq.isMove = true;
                bfq.cam_forDialogue2.enabled = true;
                bfq.cam_FPS.enabled = false;
                bfq.gg.isDialogue = true;
                //bfq.toHide.SetActive(false);
                bfq.invToHide.SetActive(false);
                bfq.goal.text = "Осталось зомби: " + bfq.gun.zombiesLeft;
                Destroy(this.gameObject);
            }
        }
        if (other.CompareTag("NPC"))
        {
            if (numOfTr == 10)
            {
                if (bfq.Kris.GetComponent<Kris>().x != bfq.Kris.GetComponent<Kris>().numberOfPoints - 1)
                {
                    bfq.Kris.GetComponent<Kris>().x++;
                    this.gameObject.SetActive(false);
                }
            }
            if (numOfTr == 11)
            {
                bfq.Kris.transform.LookAt(bfq.Steve.transform); 
                bfq.Kris.GetComponent<Kris>().animator.SetBool("isKnee", true);
                bfq.isKrisMoving = false;
                bfq.isStop = true;
            }
        }
        if (numOfTr == 13)
        {
            bfq.Kris.GetComponent<NavMeshAgent>().enabled = false;
            bfq.Kris.transform.position = new Vector3(23.7f, 0.057f, 21.09f);
            bfq.Kris.transform.eulerAngles = new Vector3(0f, -320f, 0f);

            bfq.Robert.transform.position = new Vector3(24.47f, 0.08999f, 20.58f);
            bfq.Robert.transform.eulerAngles = new Vector3(0f, -2f, 02f);

            bfq.Jess.GetComponent<Jess>().animator.SetBool("isSit", true);
            bfq.Jess.transform.position = new Vector3(21.65f, 0.2f, 21.5f);
            bfq.Jess.transform.eulerAngles = new Vector3(-5.6f, 97f, -0.7f);

            bfq.Steve.GetComponent<Steve>().animator.SetBool("isSit", true);
            bfq.Steve.transform.position = new Vector3(21.45f, 3.91f, 23.1f);
            bfq.Steve.transform.eulerAngles = new Vector3(12.9f, 186.7f, -3.06f);

            bfq.Lidia.SetActive(true);
            bfq.isWave = false;
            bfq.isMove = false;
            bfq.Lidia.GetComponent<Lidia>().animator.SetBool("isSit", true);
            bfq.Lidia.transform.position = new Vector3(22.43f, 0.25f, 21f);
            bfq.Lidia.transform.eulerAngles = new Vector3(-6.24f, -359.6f, -0.04f);

            bfq.numOfDialogueWithKris = 8;
            Destroy(this.gameObject);
        }
        if (numOfTr == 14)
        {
            bfq.areaBoss.SetActive(true);
            bfq.sliderBossHP.SetActive(true);
            Destroy(bfq.triggerForBoss);
        }
        if (numOfTr == 15)
        {
            bfq.tutorialsImg[1].SetActive(true);
            Destroy(this.gameObject);
        }
        if (numOfTr == 16)
        {
            bfq.tutorialsImg[2].SetActive(true);
            Destroy(this.gameObject);
        }
        if (numOfTr == 17)
        {
            bfq.tutorialsImg[4].SetActive(true);
            Destroy(this.gameObject);
        }
        if (numOfTr == 18)
        {
            bfq.tutorialsImg[5].SetActive(true);
            Destroy(this.gameObject);
        }
    }

}
