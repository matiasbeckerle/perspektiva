using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        GameManager.Instance.GameOver();
    }
}
