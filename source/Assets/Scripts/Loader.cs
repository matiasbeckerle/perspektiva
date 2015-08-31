using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    // UIManager prefab to instantiate.
    [SerializeField]
    GameObject uiManager;

    // SoundManager prefab to instantiate.
    [SerializeField]
    GameObject soundManager;

    // GameManager prefab to instantiate.
    [SerializeField]
    GameObject gameManager;

    void Awake()
    {
        // Check if a UIManager has already been assigned to static variable UIManager.instance or if it's still null.
        if (UIManager.Instance == null)
        {
            Instantiate(uiManager);
        }

        // Check if a SoundManager has already been assigned to static variable SoundManager.instance or if it's still null.
        if (SoundManager.Instance == null)
        {
            Instantiate(soundManager);
        }

        // GameManager should be the last one to load.
        // Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null.
        if (GameManager.Instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
