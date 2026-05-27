using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetProgressOnSceneLoad : MonoBehaviour
{
    // 싱글톤 패턴으로 초기화 데이터 관리
    private static ResetProgressOnSceneLoad instance;

    private void Awake()
    {
        // 싱글톤 패턴 유지
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 오브젝트가 씬 변경 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 존재하는 경우 새로 생성된 것을 파괴
        }
    }

    private void OnEnable()
    {
        // 씬 로드 이벤트에 초기화 메서드 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // 이벤트 등록 해제
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 특정 씬 이름 확인 후 초기화 진행
        if (scene.name == "Stage1") // "YourSceneName"을 초기화하려는 씬 이름으로 변경
        {
            ResetProgress();
        }
    }

    private void ResetProgress()
    {
        // 진행 상황 초기화 로직 구현
        Debug.Log("진행 상황이 초기화되었습니다!");

        // 예: 점수 초기화
        ClearGameManager.Instance.ResetScore();

        // 예: 플레이어 위치 초기화
        PlayerPosition.Instance.ResetPosition();

        // 다른 초기화 작업 추가
    }
}
