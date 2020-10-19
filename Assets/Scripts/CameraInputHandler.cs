using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInputHandler : MonoBehaviour
{
    private CinemachineFreeLook cinemachineFreeLook;
    private void Start()
    {
        cinemachineFreeLook = GetComponent<CinemachineFreeLook>();
    }
    public void OnLook(InputAction.CallbackContext _context)
    {
        var pointerDelta = _context.ReadValue<Vector2>();
        cinemachineFreeLook.m_XAxis.Value += pointerDelta.x;
        cinemachineFreeLook.m_YAxis.Value += pointerDelta.y;
    }
}
