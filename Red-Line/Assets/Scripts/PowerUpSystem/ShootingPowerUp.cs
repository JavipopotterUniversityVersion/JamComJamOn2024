using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ShootingPowerUp : MonoBehaviour, IPowerUp
{
    private ShootingComponent _shootingComponent;
    [SerializeField] private bool _bulletStuns;

    [SerializeField] UnityEvent powerUPEvent = new UnityEvent();

    public void Apply()
    {
        powerUPEvent.Invoke();
        _shootingComponent.enabled = true;
        _shootingComponent.BulletStuns = _bulletStuns;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _shootingComponent = collision.gameObject.GetComponentInParent<InputManager>().GetComponentInChildren<ShootingComponent>();
        Apply();
    }
}
