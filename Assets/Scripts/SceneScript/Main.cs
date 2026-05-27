using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("LoadingScene");
    }
    public void RestartGame()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }
    }
    public void gohelpScene()
    {
        SceneManager.LoadScene("HelpScene");
    }
    public void BackScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    /*void Update()
    {
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Stage1");
            }
        }
    }*/
}
