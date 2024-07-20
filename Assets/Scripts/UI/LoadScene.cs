using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadScene : MonoBehaviour
{
    public GameObject textPress;
    public Slider progressbar;
    private float t = 5;
    void Start()
    {
        StartCoroutine(LoadLevelAsinc());
    }

    private IEnumerator LoadLevelAsinc()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Global.nxtLVL);
        while (!asyncLoad.isDone)
        {
            asyncLoad.allowSceneActivation = false;

            if (t > 0)
            {
                t -= Time.deltaTime;
                progressbar.value += 0.001f;
            }
            else
            {
                if (asyncLoad.progress >= 0.9f)
                {
                    progressbar.value = 1.0f;
                    asyncLoad.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }
}
