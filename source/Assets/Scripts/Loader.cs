using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour
{
    // GameManager prefab to instantiate.
    [SerializeField]
    GameObject gameManager;

    void Awake()
    {
        // Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (GameManager.Instance == null)
        {
            Instantiate(gameManager);
        }
    }
}
