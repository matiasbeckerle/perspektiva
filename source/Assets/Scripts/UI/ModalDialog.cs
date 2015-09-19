using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ModalDialog : MonoBehaviour
{
    public static ModalDialog Instance = null;
    public Text messageText;

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
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows a message.
    /// </summary>
    /// <param name="message">The content to be shown.</param>
    public void Show(string message)
    {
        messageText.text = message;
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Shows a message and hides after a given time.
    /// </summary>
    /// <param name="message">The content to be shown.</param>
    /// <param name="secondsBeforeHiding">Seconds to wait before hiding the message.</param>
    public void Show(string message, float secondsBeforeHiding)
    {
        Show(message);
        Invoke("Hide", secondsBeforeHiding); // TODO: Is there any better way?
    }

    /// <summary>
    /// Hides the ModalDialog from the scene.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
