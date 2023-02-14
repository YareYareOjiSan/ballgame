using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private BallSpawner spawner;

    GameObject[] activeKillBalls;

    float timer = 30;
    public float killballScale = 0.5f;

    public TextMeshProUGUI scoreText, endScoreText;
    public TextMeshProUGUI hiscoreText;

    public GameObject gameoverScreen;

    public TextMeshProUGUI timerText;

    public GameObject circle;

    bool powerupSpawnable = true;
    //public TextMeshProUGUI gameOverText;
    //public Button retryButton;

    private float score;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
        }
        spawner = FindObjectOfType<BallSpawner>();
    }

    private void OnDestroy()
    {
        if (Instance == this) {
            Instance = null;
        }
    }

    private void Start()
    {
        //player = FindObjectOfType<Player>();
        //spawner = FindObjectOfType<Spawner>();
        //spawner = FindObjectOfType<BallSpawner>();
        NewGame();
    }

    public void NewGame()
    {

        score = 0f;
        enabled = true;

        //gameOverText.gameObject.SetActive(false);
        //retryButton.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameoverScreen.gameObject.SetActive(true);

        timer = 0;
    }

    private void Update()
    {

        timer -= Time.deltaTime;
        
        timerText.text = "Timer: " + Mathf.FloorToInt(timer); 


        if(timer <= 0  && circle.activeSelf == false) 
        {
            timer = 30;
            powerupSpawnable = true;
            circle.SetActive(true);

            activeKillBalls = GameObject.FindGameObjectsWithTag("Killball");

            foreach(GameObject i in activeKillBalls) 
            {
                print(i);
                Destroy(i);
            }
        }

        if(timer <= 0  && circle.activeSelf == true) 
        {
            GameOver();
        } 

        if(timer <= 20 && powerupSpawnable) 
        {
            spawner.SpawnPowerup();
            powerupSpawnable = false;
        }
    }

    public void UpdateScore()
    {
        score ++;
        scoreText.text = "Score: " + score;
        endScoreText.text = "Score: " + score;
        print(spawner);
        spawner.SpawnBalls();
    }

    public void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = "Hiscore: " + hiscore;
    }

    public IEnumerator PowerupActive()
    {
        killballScale /= 2;

        yield return new WaitForSeconds(10);

        killballScale *= 2;
        
    }

}
