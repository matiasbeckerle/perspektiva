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
    private int bricks = 0;

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

        // Keep quantity of bricks in the current level.
        bricks = GameObject.FindGameObjectsWithTag("Brick").Length;
    }

    private void CheckStatus()
    {
        // Player wins the current level.
        if (bricks == 0)
        {
            var nextLevel = (level + 1).ToString("00");

            // Player was playing the last level?
            if (nextLevel == "03")
            {
                // TODO: show a message and go back to main menu.
                Debug.Log("You win all levels!");
            }
            else
            {
                Application.LoadLevel("Level" + nextLevel);
            }
        }
    }


    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();

        // Disable this GameManager.
        enabled = false;
    }

    /// <summary>
    /// Discounts a brick from the counter.
    /// </summary>
    public void DestroyBrick()
    {
        bricks--;
        CheckStatus();
    }
}
