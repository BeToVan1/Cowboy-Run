using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text HighScoreText;

    public float scoreCount;
    public float HighScoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            HighScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        

        if(scoreCount > HighScoreCount)
        {
            HighScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", HighScoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        HighScoreText.text = "High Score: " + Mathf.Round(HighScoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
