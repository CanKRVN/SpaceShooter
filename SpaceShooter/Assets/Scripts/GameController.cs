using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public float spawnWait;
    public float waveWait;
    public int hazardCount;
    public float spawnCounter;
    public float startWait;

    public Text scoreText;
    int score;
    public GameObject gameOverPanel;
    bool isGameOver = false;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        //SpawnWaves();
        UpdateText();
    }
    private void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnWait)
        {
            for(int i = 0; i< hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
            }
            spawnCounter = 0;
        }
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateText();
    }
    
    void UpdateText()
    {
        scoreText.text = "Score : " + score;
    }


    //void SpawnWaves()
    //{
    //    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
    //    Instantiate(hazard, spawnPosition, Quaternion.identity);
    //}
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isGameOver = true;
    }

    public void RestartButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
