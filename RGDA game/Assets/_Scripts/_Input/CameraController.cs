using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSensitivity = 10f;
    [SerializeField] private float orbitOffSet = 10f;
    [SerializeField] private UIManager uiManager;

    private CameraInput inputActions;

    private void Awake()
    {
        inputActions = new CameraInput();

        inputActions.PlayerInput.Enable();
        inputActions.PlayerInput.LeftClick.started += LeftClick_started;
        inputActions.PlayerInput.ChangeTower.started += ChangeTower_started;
        inputActions.PlayerInput.Pause.started += Pause_started;
    }

    private void Pause_started(InputAction.CallbackContext obj)
    {
        uiManager.PauseGame();
    }

    private void ChangeTower_started(InputAction.CallbackContext obj)
    {
        TowerPlacementController.instance.ChangeTower();
    }

    private void LeftClick_started(InputAction.CallbackContext obj)
    {
        TowerPlacementController.instance.PlaceTower();
    }

    private void Update()
    {
        Vector2 input = inputActions.PlayerInput.Movment.ReadValue<Vector2>();


        transform.Translate(new Vector3(input.x, 0, input.y) * moveSpeed * Time.deltaTime, Space.World);
    }
}
