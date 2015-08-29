using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // Notify GameManager.
        GameManager.Instance.DestroyBrick();

        Destroy(gameObject);
    }
}
