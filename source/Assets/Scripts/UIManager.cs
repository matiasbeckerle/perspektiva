using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Static instance of UIManager which allows it to be accessed by any other script.
    public static UIManager Instance = null;

    public Text messageText;
    public GameObject messageImage;
    public float levelStartDelay = 2f;

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

    public void ShowGameOver()
    {
        messageText.text = "Game Over";
        messageImage.SetActive(true);
    }

    public void ShowLevel(int level)
    {
        messageText.text = "Level " + level;
        messageImage.SetActive(true);

        Invoke("HideMessage", levelStartDelay); // TODO: research for another better way.
    }

    private void HideMessage()
    {
        messageImage.SetActive(false);
    }
}
