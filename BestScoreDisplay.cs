using UnityEngine;
using UnityEngine.UI;

public class BestScoreDisplay : MonoBehaviour
{
    public Text bestScoreText;

    void Start()
    {
        PlayerData data = SaveSystem.LoadBestScore();
        bestScoreText.text = data.highScore.ToString();
        SoundManager.instance.PlayGameOverSound();
    }
}
