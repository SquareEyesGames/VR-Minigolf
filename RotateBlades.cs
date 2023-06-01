using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBlades : MonoBehaviour
{
    [SerializeField] private Transform _bladesTransform;
    [SerializeField] private float _rotationSpeed = 10f;

    void Update()
    {
        _bladesTransform.Rotate(Vector3.forward * _rotationSpeed * Time.deltaTime);
    }
}
