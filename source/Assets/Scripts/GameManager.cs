using UnityEngine;
using System.Collections;

/// <summary>
/// Handles the game. Little task, right?
/// </summary>
public class GameManager : MonoBehaviour
{
    // Static instance of GameManager which allows it to be accessed by any other script.
    public static GameManager Instance = null;

    public GameObject player;
    public float levelStartDelay = 2f;
    public float playerSetupDelay = 1f;

    private int lifes = 3;
    private int level = 1;
    private int bricks = 0;
    private GameObject playerClone;

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
        // UI updates.
        UIManager.Instance.ShowMessage("Level " + level, levelStartDelay);
        UIManager.Instance.UpdateCurrentLevel(level);
        UIManager.Instance.UpdateLifesQuantity(lifes);
        UIManager.Instance.ShowStats();

        // Keep quantity of bricks in the current level.
        bricks = GameObject.FindGameObjectsWithTag("Brick").Length;

        SetupPlayer();
    }

    /// <summary>
    /// Instantiates the player's prefab.
    /// </summary>
    private void SetupPlayer()
    {
        playerClone = Instantiate(player, player.transform.position, Quaternion.identity) as GameObject;
    }

    private void CheckStatus()
    {
        // Player still lives?
        if (lifes == 0)
        {
            GameOver();
        }

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

    private void GameOver()
    {
        UIManager.Instance.ShowMessage("Game Over");

        // Disable this GameManager.
        enabled = false;
    }

    public void LoseLife()
    {
        lifes--;
        UIManager.Instance.UpdateLifesQuantity(lifes);

        Destroy(playerClone);
        Invoke("SetupPlayer", playerSetupDelay);

        CheckStatus();
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
