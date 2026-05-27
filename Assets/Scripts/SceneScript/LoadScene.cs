using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LoadScene : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;

    private void Start()
    {
        StartCoroutine(SceneLoad());
    }

    IEnumerator SceneLoad()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Stage1");
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if (operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            if(progressbar.value >= 1f)
            {
                loadtext.text = "Any Key Down";
            }
            if (Input.anyKeyDown && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.ResetScore();
                }
            }
        }


    }
}
