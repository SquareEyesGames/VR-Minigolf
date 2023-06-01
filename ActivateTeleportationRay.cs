using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private GameObject _leftTeleportation;
    [SerializeField] private InputActionProperty _leftActivate;
    [SerializeField] private XRRayInteractor _leftRay;

    void Update()
    {
        bool isLeftRayHovering = _leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);

        // enables teleportation if not hovering (i.e. over menu) and if the trigger button is pressed above 0.1 strength
        _leftTeleportation.SetActive(!isLeftRayHovering && _leftActivate.action.ReadValue<float>() > 0.1f);       
    }
}
