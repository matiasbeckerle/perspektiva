using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.LoseLife();
        GameManager.Instance.SetPlaying(false);
        Destroy(other.gameObject);
    }
}
