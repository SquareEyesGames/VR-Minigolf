using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float _intensity;
    [SerializeField] private float _duration;
    [SerializeField] private XRDirectInteractor _rightHandInteractor;
    [SerializeField] private AddSpeedOnTriggerEnter _addSpeedScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            // Only trigger haptic feedback if the club had a significant speed at the time of collision
            if (_addSpeedScript != null && _addSpeedScript.GetVelocity().magnitude > 0.01f)
            {
                TriggerHaptic(_rightHandInteractor);
            }
        }
    }

    public void TriggerHaptic(XRDirectInteractor interactor)
    {
        if (_intensity > 0)
        {
            interactor.xrController.SendHapticImpulse(_intensity, _duration);
        }
    }
}

