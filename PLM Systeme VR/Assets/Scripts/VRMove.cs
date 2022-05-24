using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMove : MonoBehaviour
{
    public InputActionProperty positionProperty;
    [SerializeField] XRRayInteractor rayController;

    public Vector3 Position { get; private set; } = Vector3.zero;
    public Vector3 rayHitPosition { get; private set; } = Vector3.zero;


    private void Awake()
    {
        rayController = GetComponent<XRRayInteractor>();
    }

    private void Update()
    {
        if (rayController.TryGetHitInfo(out var hitPosition, out var hitNormal, out _, out _))
        {
            rayHitPosition = hitPosition;
        }

        Position = positionProperty.action.ReadValue<Vector3>();
    }
}

