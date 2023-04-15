using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private ActionsControl _actionControl;

    public event UnityAction MouseButtonClicked;

    private void Awake()
    {
        _actionControl = new ActionsControl();
        _actionControl.Input.Mouse.started += OnMouseButtonClick;
    }

    private void OnEnable()
    {
        _actionControl.Enable();
    }

    private void OnDisable()
    {
        _actionControl.Disable();
    }

    private void OnMouseButtonClick(InputAction.CallbackContext context)
    {
        MouseButtonClicked?.Invoke();
    }
}
