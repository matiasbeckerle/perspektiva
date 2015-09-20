using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance = null;
    public GameObject playButton;

    private bool isVisible;

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

        isVisible = true;
        gameObject.SetActive(true);

        SetDefaultButton(playButton);
    }

    /// <summary>
    /// Hides the InGameUI from the scene.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
        isVisible = false;

        SoundManager.Instance.PauseMainMenuTrack();
        SoundManager.Instance.PlayMusic();
        GameManager.Instance.ResumeGame();
    }

    public bool IsVisible()
    {
        return isVisible;
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
