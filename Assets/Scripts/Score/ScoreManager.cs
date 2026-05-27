
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // 싱글톤 패턴으로 점수 관리

    public int Score { get; private set; } // 현재 점수
    public float scoreIncreaseRate = 1f; // 점수 증가 속도 (1초당 1점)

    private float timer;

    private void Awake()
    {
        // 싱글톤 설정
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않음
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /*public void AddScore(int amount)
    {
       Score += amount;
       
    }*/
    
    private void Update()
    {
        // 시간이 지남에 따라 점수 증가
        timer += Time.deltaTime;
        if (timer >= 1f / scoreIncreaseRate)
        {
            Score++;
            timer = 0f;
        }
    }

    public void ResetScore()
    {
        Score = 0;
    }

}
