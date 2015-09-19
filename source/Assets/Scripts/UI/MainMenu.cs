using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance = null;

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

    void Start()
    {
        if (GameManager.Instance.IsGameStarted())
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    /// <summary>
    /// Shows the InGameUI in the scene.
    /// </summary>
    public void Show()
    {
        GameManager.Instance.PauseGame();
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the InGameUI from the scene.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
        GameManager.Instance.ResumeGame();
    }

    public void OnPlayButtonClick()
    {
        Application.LoadLevel("Level01");
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
