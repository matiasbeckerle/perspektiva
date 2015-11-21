using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class ModalDialog : MonoBehaviour
{
    /// <summary>
    /// Static instance of the class.
    /// </summary>
    public static ModalDialog Instance = null;

    /// <summary>
    /// Message to be shown.
    /// </summary>
    public Text messageText;

    public InputField playername;

    protected void Awake()
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

    protected void Update()
    {
        if (/*Input.GetButtonDown("Submit") || */Input.GetButtonDown("Cancel")/* || Input.GetButtonDown("Fire1")*/)
        {
            Hide();

            if (!GameManager.Instance.IsGameStarted())
            {
                MainMenu.Instance.Show();
            }
        }
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
    /// <param name="callback">Action to be executed after finishing.</param>
    public void Show(string message, float secondsBeforeHiding, Action callback = null)
    {
        Show(message);
        StartCoroutine(HideAfterTime(secondsBeforeHiding, callback));
    }

    /// <summary>
    /// Shows a message to get playername before saving score.
    /// </summary>
    /// <param name="message">The content to be shown.</param>
    /// <param name="secondsBeforeHiding">Seconds to wait before hiding the message.</param>
    /// <param name="callback">Action to be executed after finishing.</param>
    public void SaveScore(string message, Action callback = null)
    {
        Show(message);
        playername.gameObject.SetActive(true);
        //EventSystem.current.SetSelectedGameObject(input.gameObject, null);
    }

    /// <summary>
    /// Hides the ModalDialog from the scene.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
        playername.gameObject.SetActive(false);
    }

    /// <summary>
    /// Hides the ModalDialog after a given time.
    /// </summary>
    /// <param name="seconds">Seconds to wait before hiding the message.</param>
    /// <param name="callback">Action to be executed after finishing.</param>
    /// <returns></returns>
    private IEnumerator HideAfterTime(float seconds, Action callback = null)
    {
        yield return new WaitForSeconds(seconds);

        Hide();

        if (callback != null)
        {
            callback();
        }
    }
}
