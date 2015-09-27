using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Static instance of the class.
    /// </summary>
    public static MainMenu Instance = null;

    /// <summary>
    /// The play button reference.
    /// </summary>
    public GameObject playButton;

    /// <summary>
    /// Flag for knowing when the main menu is visible or not.
    /// </summary>
    private bool _isVisible;

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
    }

    protected void Start()
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
    /// Sets the default button as selected.
    /// </summary>
    /// <param name="defaultButton">The button to be set as selected.</param>
    private void SetDefaultButton(GameObject defaultButton)
    {
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(defaultButton);
    }

    /// <summary>
    /// Shows the InGameUI in the scene.
    /// </summary>
    public void Show()
    {
        GameManager.Instance.PauseGame();
        SoundManager.Instance.PauseMusic();
        SoundManager.Instance.PlayMainMenuTrack();

        _isVisible = true;
        gameObject.SetActive(true);

        SetDefaultButton(playButton);
    }

    /// <summary>
    /// Hides the InGameUI from the scene.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
        _isVisible = false;

        SoundManager.Instance.PauseMainMenuTrack();
        SoundManager.Instance.PlayMusic();
        GameManager.Instance.ResumeGame();
    }

    /// <summary>
    /// Gets if the main menu is visible or not.
    /// </summary>
    /// <returns>Main menu's visibility status.</returns>
    public bool IsVisible()
    {
        return _isVisible;
    }

    /// <summary>
    /// Callback for "play" button.
    /// Starts a new game.
    /// </summary>
    public void OnPlayButtonClick()
    {
        GameManager.Instance.ResetGame();
        Application.LoadLevel("Level01");
    }

    /// <summary>
    /// Callback for "exit" button.
    /// Closes the game.
    /// </summary>
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
