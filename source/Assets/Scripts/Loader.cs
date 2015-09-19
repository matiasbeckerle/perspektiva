using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    // ModalDialog prefab to instantiate.
    [SerializeField]
    GameObject modalDialog;

    // MainMenu prefab to instantiate.
    [SerializeField]
    GameObject mainMenu;

    // InGameUI prefab to instantiate.
    [SerializeField]
    GameObject inGameUI;

    // SoundManager prefab to instantiate.
    [SerializeField]
    GameObject soundManager;

    // GameManager prefab to instantiate.
    [SerializeField]
    GameObject gameManager;

    void Awake()
    {
        // Check if the instances have already been assigned to static variables or they are still null.

        if (ModalDialog.Instance == null)
        {
            Instantiate(modalDialog);
        }
        if (MainMenu.Instance == null)
        {
            Instantiate(mainMenu);
        }
        if (InGameUI.Instance == null)
        {
            Instantiate(inGameUI);
        }
        if (SoundManager.Instance == null)
        {
            Instantiate(soundManager);
        }
        if (GameManager.Instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
