using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReverseInputPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private float _secondsToUnRevert;
    [SerializeField] UnityEvent _onApply = new UnityEvent();
    private InputManager _playerInput;
    public void Apply()
    {
        _playerInput.ReverseControls(_secondsToUnRevert);
        _onApply.Invoke();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _playerInput = collision.GetComponentInParent<InputManager>();
        Apply();
    }
}

