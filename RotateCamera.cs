using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;     // Target the camera circles around (0, 0, 0)
    [SerializeField] private float _rotationspeed = 10.0f;
    [SerializeField] private Canvas _canvas;

    private void Start()
    {
        if (_canvas.renderMode != RenderMode.WorldSpace)
        {
            Debug.LogWarning("Changing canvas render mode to World Space.");
            _canvas.renderMode = RenderMode.WorldSpace;
        }

        // Position the canvas as a child of the camera
        _canvas.transform.SetParent(transform, false);
        // Move it forward slightly so it isn't clipping with anything in the camera view
        _canvas.transform.localPosition = new Vector3(0, 0, 0.5f);
        // Make sure it's facing the camera
        _canvas.transform.localRotation = Quaternion.identity;
    }

    void Update()
    {
        transform.RotateAround(_target.position, Vector3.up, _rotationspeed * Time.deltaTime);
    }
}
