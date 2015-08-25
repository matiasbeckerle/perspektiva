using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Static instance of UIManager which allows it to be accessed by any other script.
    public static UIManager Instance = null;

    public Text levelText;
    public GameObject levelImage;
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

    public void ShowLevel(int level)
    {
        levelText.text = "Level " + level;
        levelImage.SetActive(true);

        Invoke("HideLevel", levelStartDelay);
    }

    public void HideLevel()
    {
        levelImage.SetActive(false);
    }
}
