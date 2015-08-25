using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the game. Little task, right?
/// </summary>
public class GameManager : MonoBehaviour
{
    // Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager Instance = null;

    private int level = 1;

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

        // Initialize the first level.
        InitGame();
    }

    private void OnLevelWasLoaded(int index)
    {
        level++;
        InitGame();
    }

    private void InitGame()
    {
        UIManager.Instance.ShowLevel(level);
    }

    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();

        // Disable this GameManager.
        enabled = false;
    }
}
