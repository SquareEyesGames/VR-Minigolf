using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableTwoAttach : XRGrabInteractable       // uses the GrabInteractible Script and...
{
    [SerializeField] private Transform _leftAttachTransform;
    [SerializeField] private Transform _rightAttachTransform;

    protected override void OnSelectEntered(SelectEnterEventArgs args)      // ...overrides the attach point for each respective hand
    {
        if(args.interactorObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = _leftAttachTransform;
        }
        else if (args.interactorObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = _rightAttachTransform;
        }

        base.OnSelectEntered(args);
    }
}
