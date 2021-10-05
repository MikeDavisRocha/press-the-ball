using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    private float timeStart = 15f;
    public Text textBox;

    private void Start()
    {
        textBox.text = timeStart.ToString();
    }

    private void Update()
    {
        timeStart -= Time.deltaTime;
        textBox.text = Mathf.Round(timeStart).ToString("00:00");

        if (timeStart <= 0)
        {
            SoundManager.instance.StopFiveSecondsLeftAudio();
            LevelManager.instance.LoadLoseScene();
        }
        if ((timeStart > 0 && timeStart <= 5) && !SoundManager.instance.isLastFiveSecondsRunning)
        {
            SoundManager.instance.isLastFiveSecondsRunning = true;
            SoundManager.instance.PlayFiveSecondsLeftAudio();
        }
    }

    public void ResetTime()
    {
        timeStart = 15f;
    }
}
