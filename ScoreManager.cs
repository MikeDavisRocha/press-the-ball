using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    int score, highScore;

    public void AddScore()
    {
        score++;
        UpdateHighScore();
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
        }
    }    

    public void SaveScore()
    {
        SaveSystem.SaveScore(this);
    }

    public void SaveHighScore()
    {
        PlayerData data = SaveSystem.LoadBestScore();

        if (data == null || data.highScore < highScore)
        {
            SaveSystem.SaveBestScore(this);
        }
    }
}
