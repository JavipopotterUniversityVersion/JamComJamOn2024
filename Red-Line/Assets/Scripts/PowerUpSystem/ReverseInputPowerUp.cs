using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseInputPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private float _secondsToUnRevert;
    private InputManager _playerInput;
    public void Apply()
    {
        _playerInput.ReverseControls(_secondsToUnRevert);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerInput = collision.GetComponentInChildren<InputManager>();
        Apply();
    }
}
