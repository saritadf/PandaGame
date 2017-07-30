using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //access text

public class ScoreManager : MonoBehaviour {
    //text
    public Text scoreText;
    public Text highScoreText;
    public Text coinsText;
    public Text totalCoinsText;

    //floats'
    public float totalCoinsCount;
    public float coinsCount;
    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    private float nextActionTime = 0.0f;
    public float lifePeriodTime;
    private float timeVariable;
    
    //bool
    public bool scoreIncreasing;
    public bool lifeDecreasing;
    private bool firstTime;
    public bool coinWasPicked;

    //references
    private Player player;

    private void Start()
    {
        firstTime = true;
        coinWasPicked = false;

        //import value of highScore and TotalCoins
        if (PlayerPrefs.HasKey("HighScore")) {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }

        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            highScoreCount = PlayerPrefs.GetFloat("TotalCoins");
        }
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime/2;
        }

        if (scoreCount > highScoreCount)
        { highScoreCount = scoreCount;
            //save in prefabs "HighScore"(just created here) highScoreCount value to load it every time the game start 
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

              

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);

        timeVariable += 1 * Time.deltaTime;

        //decrease life each "lifePeriodTime" secounds //nextActionTime is the total time the game have plus the lifePeriodTime
        if (lifeDecreasing && timeVariable > nextActionTime)
        {
            nextActionTime += lifePeriodTime;
            if (!firstTime)
            {
           
            player.Damage(1);
            }
            else firstTime = false;
        }

        //--------COINS--------------------------
        if (coinWasPicked)
        {
            totalCoinsCount += coinsCount;
            coinWasPicked=false;
        }

        //save in prefabs "TotalCoins"(just created here) totalCoins value to load it every time the game start 
        PlayerPrefs.SetFloat("TotalCoins", totalCoinsCount);

        coinsText.text = "Coins: " + coinsCount;
        totalCoinsText.text = "Total Coins: " + totalCoinsCount;


    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;

    }

    public void AddCoins(int coinsToAdd)
    {
        coinsCount += coinsToAdd;

    }


}
