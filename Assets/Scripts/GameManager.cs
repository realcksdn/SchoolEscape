using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObjs;
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public GameObject player;

    private static GameManager _instance;
    public static GameManager Instance;

    /*private void Awake() // 싱글톤
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else if (_instance != this)
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }*/

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드 이벤트 연결
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 씬 로드 이벤트 해제
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        curSpawnDelay = 0; // 딜레이 초기화
       

    }

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 3f);
            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length < 1 || enemyObjs.Length < 1)
        {
            Debug.LogWarning("Spawn points or enemy objects are not set.");
            return;
        }

        int ranEnemy = Random.Range(0, enemyObjs.Length);
        int ranPoint = Random.Range(0, spawnPoints.Length);

        GameObject enemy = Instantiate(enemyObjs[ranEnemy],
                spawnPoints[ranPoint].position,
                spawnPoints[ranPoint].rotation);

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        Enemy enemyLogic = enemy.GetComponent<Enemy>();
        enemyLogic.player = player;

        Vector2 moveDirection = Vector2.down;

        /*if (ranPoint >= 5 && ranPoint <= 6)
        {
            enemy.transform.Rotate(Vector3.back * 90);
            moveDirection = new Vector2(-1, -1);
        }*/
        

        rb.velocity = moveDirection.normalized * enemyLogic.speed;
    }
}

