using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugUI : MonoBehaviour
{
    public static DebugUI Instance = null;
    public Text framesPerSecond;

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

        if (Debug.isDebugBuild || Application.isEditor)
        {
            Show();
        }
    }

    /// <summary>
    /// Shows the InGameUI in the scene.
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the InGameUI from the scene.
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates FPS counter value.
    /// </summary>
    /// <param name="frames">Number of current quantity of frames per second.</param>
    public void UpdateFramesPerSecond(float frames = 0)
    {
        framesPerSecond.text = frames.ToString("0.0");
    }
}
