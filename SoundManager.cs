using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioClip fiveSecondsLeftAudio, gameOverSound, tapOnBallSound, buttonsSound, hitOneScoreSound;
    [SerializeField] [Range(0, 1)] float audiosVolume = 0.5f;

    private bool isSoundOn = true;
    private bool isVibrateOn = true;
    public bool isLastFiveSecondsRunning = false;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SoundOnOff()
    {
        instance.isSoundOn = !instance.isSoundOn;
    }

    public void Vibration()
    {
        if (instance.isVibrateOn)
        {
            Vibrator.Vibrate();
        }
    }

    public void VibrationOnOff()
    {
        instance.isVibrateOn = !instance.isVibrateOn;
        if (Application.platform == RuntimePlatform.Android)
        {
            Vibration();
        }
    }

    public void PlayFiveSecondsLeftAudio()
    {
        if (instance.isSoundOn)
        {
            audioSource.clip = fiveSecondsLeftAudio;
            audioSource.Play();
        }
    }

    public void StopFiveSecondsLeftAudio()
    {
        audioSource.Stop();
    }

    public void PlayGameOverSound()
    {
        if (instance.isSoundOn)
        {
            AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position, audiosVolume);
        }
    }

    public void PlayTapOnBallSound()
    {
        if (instance.isSoundOn)
        {
            AudioSource.PlayClipAtPoint(tapOnBallSound, Camera.main.transform.position, audiosVolume);
        }
    }

    public void PlayButtonsSound()
    {
        if (instance.isSoundOn)
        {
            AudioSource.PlayClipAtPoint(buttonsSound, Camera.main.transform.position, audiosVolume);
        }
    }

    public void PlayHitOneScoreSound()
    {
        if (instance.isSoundOn)
        {
            AudioSource.PlayClipAtPoint(hitOneScoreSound, Camera.main.transform.position, audiosVolume);
        }
    }
}
