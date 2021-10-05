using UnityEngine;

public class LoadButtonState : MonoBehaviour
{
    public GameObject soundButtonOn, soundButtonOff, vibrationButtonOn, vibrationButtonOff;

    void Start()
    {
        LoadButton();
    }

    public void LoadButton()
    {
        soundButtonOn.SetActive(ButtonManager.instance.SoundButtonState);
        soundButtonOff.SetActive(!ButtonManager.instance.SoundButtonState);
        vibrationButtonOn.SetActive(ButtonManager.instance.VibrationButtonState);
        vibrationButtonOff.SetActive(!ButtonManager.instance.VibrationButtonState);
    }


    public void ChangeSoundButtonState()
    {
        ButtonManager.instance.SoundButtonState = !ButtonManager.instance.SoundButtonState;
    }

    public void ChangeVibrationButtonState()
    {
        ButtonManager.instance.VibrationButtonState = !ButtonManager.instance.VibrationButtonState;
    }
}
