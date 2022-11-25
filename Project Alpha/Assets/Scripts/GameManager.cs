using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject powerUpPrefab;
    private float spawnRate = 1.0f;
    private float powerUpSpawnRate = 7.0f;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    public Button restartButton;
    public GameObject titleScreen;

    private int score;
    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
           yield return new WaitForSeconds(spawnRate);
           int index = Random.Range(0, targets.Count);
           Instantiate(targets[index]);
        }
    }

    IEnumerator SpawnPowerUp()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(powerUpSpawnRate);
            Instantiate(powerUpPrefab);
        }
    }

    public void StartTimer()
    {
        StartCoroutine(powerUpCountdownRoutine());
    }

    IEnumerator powerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 1.0f;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }
}
