using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int score, highScore;

    public PlayerData(ScoreManager scoreManager)
    {
        score = scoreManager.GetScore();
        highScore = scoreManager.GetHighScore();
    }
}
