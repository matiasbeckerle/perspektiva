using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float initialVelocity = 500f;

    private Rigidbody rb;
    private bool playing = false; // TODO: "playing" could be "GameManager" responsability.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !playing)
        {
            playing = true;
            transform.parent = null;
            rb.isKinematic = false;
            rb.AddForce(new Vector3(initialVelocity, initialVelocity, 0));
        }
    }
}
