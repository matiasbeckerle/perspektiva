using UnityEngine;
using System.Collections;

public class FramesPerSecond : MonoBehaviour
{
    /// <summary>
    /// Delta time reference to be used in FPS calculation.
    /// </summary>
    private float _dt = 0;

    /// <summary>
    /// Keeps track of current quantity of FPS.
    /// </summary>
    private float _fps = 0;

    /// <summary>
    /// Quantity of updates per second.
    /// </summary>
    private float _updateRate = 4;

    /// <summary>
    /// Keeps track of frames counter to be used in conjunction with `updateRate`.
    /// </summary>
    private float _frameCount = 0;

    protected void Update()
    {
        if (Debug.isDebugBuild || Application.isEditor)
        {
            _frameCount++;
            _dt += Time.deltaTime;

            if (_dt > 1 / _updateRate)
            {
                _fps = _frameCount / _dt;
                _frameCount = 0;
                _dt -= 1 / _updateRate;

                DebugUI.Instance.UpdateFramesPerSecond(_fps);
            }
        }
    }
}
