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
    public AudioClip loseLifeSound;

    /// <summary>
    /// State that represents when the player has started a new game.
    /// </summary>
    private bool gameStarted = false;

    /// <summary>
    /// State that represents when the ball is moving.
    /// </summary>
    private bool playing = false;

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
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (MainMenu.Instance.IsVisible())
            {
                if (gameStarted)
                {
                    MainMenu.Instance.Hide();
                }
            }
            else
            {
                MainMenu.Instance.Show();
            }
        }
    }

    private void OnLevelWasLoaded(int index)
    {
        // Increase level only when the game already started.
        if (gameStarted)
        {
            level++;
        }

        InitLevel();
    }

    public void InitLevel()
    {
        gameStarted = true;
        playing = false;

        // UI updates.
        MainMenu.Instance.Hide();
        ModalDialog.Instance.Show("Level " + level, levelStartDelay);
        InGameUI.Instance.UpdateCurrentLevel(level);
        InGameUI.Instance.UpdateLifesQuantity(lifes);
        InGameUI.Instance.Show();

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
            if (nextLevel == "10")
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
        ModalDialog.Instance.Show("Game Over");

        // Disable this GameManager.
        enabled = false;
    }

    public int GetCurrentLevel()
    {
        return level;
    }

    public void LoseLife()
    {
        lifes--;
        InGameUI.Instance.UpdateLifesQuantity(lifes);
        SoundManager.Instance.PlaySingle(loseLifeSound);

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

    public bool IsGameStarted()
    {
        return gameStarted;
    }

    public bool IsPlaying()
    {
        return playing;
    }

    public void SetPlaying(bool value)
    {
        playing = value;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
