using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.LoseLife();
        Destroy(other.gameObject);
    }
}
