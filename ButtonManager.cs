using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public static ButtonManager Instance { get { return instance; } }

    bool soundButtonState = true, vibrationButtonState = true;

    public bool SoundButtonState { get { return soundButtonState; } set { soundButtonState = value; } }
    public bool VibrationButtonState { get { return vibrationButtonState; } set { vibrationButtonState = value; } }

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
}
