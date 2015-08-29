using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Static instance of UIManager which allows it to be accessed by any other script.
    public static UIManager Instance = null;

    public Text messageText;
    public GameObject messageImage;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Shows a message at full size screen.
    /// </summary>
    /// <param name="message">The content to be shown.</param>
    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageImage.SetActive(true);
    }

    /// <summary>
    /// Shows a message at full size screen and hides after a given time.
    /// </summary>
    /// <param name="message">The content to be shown.</param>
    /// <param name="secondsToHide">Seconds to wait before hiding the message.</param>
    public void ShowMessage(string message, float secondsToHide)
    {
        ShowMessage(message);
        Invoke("HideMessage", secondsToHide); // TODO: research for another better way.
    }

    private void HideMessage()
    {
        messageImage.SetActive(false);
    }
}
