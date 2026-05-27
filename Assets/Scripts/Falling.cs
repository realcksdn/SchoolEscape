using UnityEngine;
using UnityEngine.UI;

public class Falling : MonoBehaviour
{
    public GameObject uiPrefab;    // 떨어질 UI의 프리팹
    public Transform canvasTransform; // UI가 생성될 캔버스의 Transform
    public float fallSpeed = 30f; // 떨어지는 속도
    public float delayTime = 60f;  // 몇 초 후 UI가 생성될지

    private float timer = 0f;      // 타이머
    private GameObject spawnedUI; // 동적으로 생성된 UI

    private void Update()
    {
        // 타이머 증가
        timer += Time.deltaTime;

        // 60초 후 UI 생성
        if (timer >= delayTime && spawnedUI == null)
        {
            SpawnUI(); // UI 생성
        }

        // UI가 생성되었을 때 떨어지는 로직
        if (spawnedUI != null)
        {
            RectTransform rectTransform = spawnedUI.GetComponent<RectTransform>();
            rectTransform.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;

            // UI가 화면 밖으로 나가면 삭제
            if (rectTransform.anchoredPosition.y < -Screen.height)
            {
                Destroy(spawnedUI); // 생성된 UI 삭제
            }
        }
    }

    private void SpawnUI()
    {
        // UI 프리팹 생성
        spawnedUI = Instantiate(uiPrefab, canvasTransform);
        RectTransform rectTransform = spawnedUI.GetComponent<RectTransform>();

        // 생성 위치 설정 (화면 상단 중앙)
        rectTransform.anchoredPosition = new Vector2(0, Screen.height);
    }
}
