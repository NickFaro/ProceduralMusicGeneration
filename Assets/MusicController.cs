using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public MusicManager musicManager;
    public Button playButton;
    public Button stopButton;

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(musicManager.PlayMusic);
        }
        else
        {
            Debug.LogError("Play button is not assigned.");
        }

        if (stopButton != null)
        {
            stopButton.onClick.AddListener(musicManager.StopMusic);
        }
        else
        {
            Debug.LogError("Stop button is not assigned.");
        }

        if (musicManager == null)
        {
            Debug.LogError("Music Manager is not assigned.");
        }
    }
}
