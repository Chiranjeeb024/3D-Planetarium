using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject loadingScreen;
    public Slider slider;
    public Text ProgressText;

    public void LoadLevel1 (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
         loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
           
            slider.value = progress;
            ProgressText.text = progress * 100f + "%";
            yield return null;


        }

    }
}
