using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("1 - Menu");
    }

    public void LoadPlayScene()
    {
        SoundManager.instance.isLastFiveSecondsRunning = false;
        SceneManager.LoadScene("2 - Play");
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene("3 - Lose");
    }
}
