﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public float initialVelocity = 500f;
    public AudioClip brickExplosionSound1;
    public AudioClip brickExplosionSound2;
    public AudioClip brickExplosionSound3;
    public AudioClip wallHitSound1;
    public AudioClip wallHitSound2;
    public GameObject sparks;

    private Rigidbody rb;
    private bool playing = false; // TODO: "playing" could be "GameManager" responsability.
    private float initialVelocityPerLevel;
    private CameraShake shaker;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        shaker = GetComponent<CameraShake>();

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
            shaker.Shake(1);

            // Add sparks particles and removes it after some seconds.
            var sparksInstance = Instantiate(sparks, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(sparksInstance, 3);

            SoundManager.Instance.RandomizeSfx(wallHitSound1, wallHitSound2);
        }
    }
}
