using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;

public class CameraModeSwitcher : MonoBehaviour
{
    [Header("Cinemachine Cameras")]
    [SerializeField] private CinemachineCamera thirdPersonCamera;
    [SerializeField] private CinemachineCamera firstPersonCamera;

    private bool isFirstPerson;

    private void Start()
    {
        SetThirdPerson();
    }

    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.qKey.wasPressedThisFrame)
        {
            ToggleCameraMode();
        }
    }

    private void ToggleCameraMode()
    {
        if (isFirstPerson)
        {
            SetThirdPerson();
        }
        else
        {
            SetFirstPerson();
        }
    }

    private void SetThirdPerson()
    {
        isFirstPerson = false;

        if (thirdPersonCamera != null)
        {
            thirdPersonCamera.Prioritize();
        }
    }

    private void SetFirstPerson()
    {
        isFirstPerson = true;

        if (firstPersonCamera != null)
        {
            firstPersonCamera.Prioritize();
        }
    }
}