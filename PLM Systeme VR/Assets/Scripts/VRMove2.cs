using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMove2 : XRGrabInteractable
{

    [SerializeField] XRRayInteractor ray;

    private Vector3 mOffset;
    public XRController rController;
    private InputAction snap;
    //public ControllerPosition controllerPosition = null;

    protected override void Awake()
    {
        snap = InputActionAsset.
        base.Awake();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        rController = args.interactor.GetComponent<XRController>();

        mOffset = gameObject.transform.position - snap.rayHitPosition;

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        controllerPosition = null;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            if (updatePhase == XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            {
                UpdateObjectPosition();
            }
        }
    }

    private void UpdateObjectPosition()
    {
        Vector3 position = controllerPosition ? controllerPosition.Position : Vector3.zero;

        transform.position = controllerPosition.rayHitPosition + mOffset;

    }
}
}
