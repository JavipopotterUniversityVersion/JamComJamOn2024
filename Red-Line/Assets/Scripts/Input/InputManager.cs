using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    JointController jointController;
    WebReleaser webReleaser;
    Dash dash;


    private void Awake() {
        webReleaser = GetComponentInChildren<WebReleaser>();
        jointController = GetComponentInChildren<JointController>();
        dash = GetComponentInChildren<Dash>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 direction = new Vector2(context.ReadValue<Vector2>().x, 0);
        jointController.Move(direction);
    }

    public void Dash(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            dash.DashAction();
        }
    }

    public void ThrowWeb(InputAction.CallbackContext context)
    {
        webReleaser.ThrowWeb(context.ReadValue<Vector2>().y);
    }
}
