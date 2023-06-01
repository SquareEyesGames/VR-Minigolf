using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour
{
    [SerializeField] private InputActionProperty _pinchAnimationAction;
    [SerializeField] private InputActionProperty _gripAnimationAction;
    [SerializeField] private Animator _handAnimator;

    void Update()
    {
        // Pinch Animation
        float triggerValue = _pinchAnimationAction.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", triggerValue);

        // Grip Animation
        float gripValue = _gripAnimationAction.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", gripValue);
    }
}
