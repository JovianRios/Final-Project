using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public TimeManager timeManager;

    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;


    float currentTime = 0f;
    float startingTime = 30f;

    public Text PointsText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text countdownText;


    public int score;
    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        currentTime = startingTime;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SceneManager.LoadScene("Main");
            }
        }
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("Countdown: 0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                Destroy(this);
                {
                    winText.text = "Congrats! Game created by Jovian Rios!";
                    Destroy(this);
                    musicSource.clip = musicClipOne;
                    musicSource.Play();
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Application.Quit();
                    }
                }
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'Y' to Restart";
                restart = true;
                break;
            }
            if (Input.GetKey("escape"))
                Application.Quit();
        }
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        PointsText.text = "Points: " + score;
        if (score >= 750)
        {
            winText.text = "Great job! You've reached maxed points!";
            gameOver = true;
            restart = true;
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (score >= 200)
        {
            timeManager.DoSlowmotion();
        }
    }
    public void GameOver()
    {
        winText.text = "Game Over!";
        gameOver = true;
        musicSource.clip = musicClipTwo;
        musicSource.Play();

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
