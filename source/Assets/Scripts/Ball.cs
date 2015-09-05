using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float initialVelocity = 500f;
    public AudioClip brickExplosionSound1;
    public AudioClip brickExplosionSound2;
    public AudioClip brickExplosionSound3;
    public AudioClip wallHitSound1;
    public AudioClip wallHitSound2;

    private Rigidbody rb;
    private bool playing = false; // TODO: "playing" could be "GameManager" responsability.
    private float initialVelocityPerLevel;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        // Each level adds a little bit of velocity to make it challenger.
        initialVelocityPerLevel = initialVelocity + (50 * GameManager.Instance.GetCurrentLevel());
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !playing)
        {
            playing = true;
            transform.parent = null;
            rb.isKinematic = false;

            rb.AddForce(new Vector3(initialVelocityPerLevel, initialVelocityPerLevel, 0));
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            SoundManager.Instance.RandomizeSfx(brickExplosionSound1, brickExplosionSound2, brickExplosionSound3);
        }
        else
        {
            SoundManager.Instance.RandomizeSfx(wallHitSound1, wallHitSound2);
        }
    }
}
