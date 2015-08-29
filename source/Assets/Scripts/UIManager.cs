using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Static instance of UIManager which allows it to be accessed by any other script.
    public static UIManager Instance = null;

    public GameObject messageCanvas;
    public Text messageText;

    public GameObject statsCanvas;
    public Text currentLevelText;
    public Text lifesQuantityText;

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

    private void HideAll()
    {
        HideStats();
        HideMessage();
    }

    /// <summary>
    /// Shows a message at full size screen.
    /// </summary>
    /// <param name="message">The content to be shown.</param>
    public void ShowMessage(string message)
    {
        messageText.text = message;
        HideAll();
        messageCanvas.SetActive(true);
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
        messageCanvas.SetActive(false);
    }

    public void ShowStats()
    {
        statsCanvas.SetActive(true);
    }

    private void HideStats()
    {
        statsCanvas.SetActive(false);
    }

    public void UpdateLifesQuantity(int lifesQuantity)
    {
        lifesQuantityText.text = lifesQuantity.ToString();
    }

    public void UpdateCurrentLevel(int level)
    {
        currentLevelText.text = level.ToString();
    }
}
