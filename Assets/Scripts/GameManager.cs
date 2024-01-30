using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] targetPrefabs;

    private float minX = -3.75f;
    private float minY = -3.75f;
    private float distanceBetweenCenter = 2.5f;

    private bool isGameOver;

    private float spawnRate = 2f; //Los targets aparecerán cada 2 segundos

    private Vector3 randomPos;
    public List<Vector3> targetPositionsInScene;

    private int score;
    private int time;
    private int timeMax = 60;

    private UIManager uiManager;


    private void Awake()
    {
        targetPositionsInScene = new List<Vector3>();
    }


    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.HideGameOverPanel();
        uiManager.ShowMainMenuPanel();
        
    }

    void Update()
    {
        IsGameOver();
    }

    public void StartGame(int difficulty)
    {
        uiManager.HideMainMenuPanel();

        score = 0;
        UpdateScore(0);

        time = timeMax / difficulty;
        uiManager.UpdateTimeText(time);

        spawnRate = spawnRate / difficulty;

        StartCoroutine(SpawnRandomTarget());
        StartCoroutine(Timer());
    }

    private Vector3 RandomSpawnPosition()
    {
        // -3.75, 1.25, 1.25, 3.75
        float spawnPosX = minX + Random.Range(0, 4) * distanceBetweenCenter;
        float spawnPosY = minY + Random.Range(0, 4) * distanceBetweenCenter;

        return new Vector3(spawnPosX, spawnPosY, 0);

    }

    private IEnumerator SpawnRandomTarget()
    {

        while (!isGameOver)
        {
            yield return new WaitForSeconds(spawnRate);

            if (isGameOver)
            {
                
                break;
            }

            int randomPrefabsIndex = Random.Range(0, targetPrefabs.Length);

            randomPos = RandomSpawnPosition();
            while (targetPositionsInScene.Contains(randomPos))
            {
                randomPos = RandomSpawnPosition();
            }

            Instantiate(targetPrefabs[randomPrefabsIndex], randomPos, targetPrefabs[randomPrefabsIndex].transform.rotation);

            targetPositionsInScene.Add(randomPos);

        }
        
    }

    private IEnumerator Timer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1);

            if (isGameOver)
            {
                break;
            }

            UpdateTime();
        }
    }

    private void UpdateTime()
    {
        time--;
        uiManager.UpdateTimeText(time);

        if (time <= 0)
        {
            isGameOver = true;
            uiManager.ShowGameOverPanel(score);
        }

    }

    public void UpdateScore(int newPoints)
    {
        score += newPoints;
        uiManager.UpdateScoreText(score);

        if (score < 0)
        {
            isGameOver = true;
            uiManager.ShowGameOverPanel(score);

        }

    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void RestartGameScene()
    {
        SceneManager.LoadScene(0);
    }

}
