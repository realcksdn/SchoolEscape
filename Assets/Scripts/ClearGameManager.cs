using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearGameManager : MonoBehaviour
{
    public static ClearGameManager Instance;

    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetScore()
    {
        score = 0;
        Debug.Log("점수가 초기화되었습니다!");
    }
}
