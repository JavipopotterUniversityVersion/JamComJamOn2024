using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    JointController jointController;
    WebReleaser webReleaser;
    Dash dash;

    private bool _controlsReversed = false;


    private void Awake() {
        webReleaser = GetComponentInChildren<WebReleaser>();
        jointController = GetComponentInChildren<JointController>();
        dash = GetComponentInChildren<Dash>();
    }

    public void Move(InputAction.CallbackContext context)
    {
        int directionSense = (_controlsReversed) ? -1 : 1;

        Vector2 direction = new Vector2(context.ReadValue<Vector2>().x * directionSense, 0);
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
        int directionSense = (_controlsReversed) ? -1 : 1;

        webReleaser.ThrowWeb(context.ReadValue<Vector2>().y * directionSense);
    }

    public void ReverseControls(float seconds)
    {
        StartCoroutine(ReverseUnReverse(seconds));
    }

    private IEnumerator ReverseUnReverse(float seconds) 
    {
        _controlsReversed = !_controlsReversed;
        yield return new WaitForSeconds(seconds);
        _controlsReversed = !_controlsReversed;
    }
}
