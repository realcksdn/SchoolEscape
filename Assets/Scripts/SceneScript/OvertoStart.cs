using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OvertoStart : MonoBehaviour
{
    public void ReButton()
    {
        SceneManager.LoadScene("StartScene");
    }
}
