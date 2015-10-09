using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    /// <summary>
    /// Paddle's speed.
    /// </summary>
    public float speed = 20;

    /// <summary>
    /// Store the direction of the paddle's movement.
    /// </summary>
    Vector3 _movement;

    /// <summary>
    /// Rigidbody reference.
    /// </summary>
    private Rigidbody _rigidbody;

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        _movement.Set(h, 0, 0);
        _movement = _movement.normalized * speed * Time.deltaTime;

        _rigidbody.MovePosition(transform.position + _movement);
    }
}
