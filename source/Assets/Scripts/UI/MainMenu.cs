using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance = null;
    public GameObject playButton;

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

        SetDefaultButton(playButton);
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
