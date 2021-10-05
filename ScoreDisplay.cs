using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        PlayerData data = SaveSystem.LoadScore();
        scoreText.text = data.score.ToString();
    }
}
