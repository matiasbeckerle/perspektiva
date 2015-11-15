using UnityEngine;
using System.Collections;

public class CameraToggle : MonoBehaviour
{
    private Camera _mainCamera;
    private Camera _ballCamera;

    protected void Start()
    {
        _mainCamera = GetComponent<Camera>();
    }

    protected void FixedUpdate()
    {
        // On MAIN button enabled
        // AND the ball camera is ready too
        // AND the ball is already moving on
        // ---> Activate the ball camera.
        if (Input.GetAxisRaw("Fire1") != 0 && GameManager.Instance.IsBallCameraReady() && GameManager.Instance.IsPlaying())
        {
            EnableBallCamera();
        }
        // On MAIN button disabled
        // AND the ball is already moving on
        // ---> deactivate the ball camera.
        else if (GameManager.Instance.IsPlaying())
        {
            DisableBallCamera();
        }
    }

    /// <summary>
    /// Activates the ball camera and disables main.
    /// </summary>
    private void EnableBallCamera()
    {
        CheckBallCamera();
        _mainCamera.enabled = false;
        _ballCamera.enabled = true;
    }

    /// <summary>
    /// Deactivates the ball camera and activates main.
    /// </summary>
    private void DisableBallCamera()
    {
        CheckBallCamera();
        _ballCamera.enabled = false;
        _mainCamera.enabled = true;
    }

    /// <summary>
    /// Sets the ball camera when is null.
    /// Not so nice... but the ball is dinamically instantiated and not available on the scene every frame.
    /// </summary>
    private void CheckBallCamera()
    {
        if (_ballCamera == null)
        {
            _ballCamera = GameObject.Find("BallCamera").GetComponent<Camera>();
        }
    }
}
