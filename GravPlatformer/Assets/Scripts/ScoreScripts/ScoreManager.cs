using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    int score = 0;
    int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();
        UpdateScore();
    }

    public void AddPoints(int points)
    {
        score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "SCORE: " + score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

}
