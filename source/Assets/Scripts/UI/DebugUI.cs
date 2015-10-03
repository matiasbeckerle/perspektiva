using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugUI : MonoBehaviour
{
    /// <summary>
    /// Static instance of the class.
    /// </summary>
    public static DebugUI Instance = null;

    /// <summary>
    /// Frames per second text reference.
    /// </summary>
    public Text framesPerSecondText;

    /// <summary>
    /// Game version text reference.
    /// </summary>
    public Text versionText;

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

    protected void Start()
    {
        versionText.text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString() + " [alpha]";
    }

    /// <summary>
    /// Shows the DebugUI in the scene.
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// Hides the DebugUI from the scene.
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
        framesPerSecondText.text = frames.ToString("0.0 FPS");
    }
}
