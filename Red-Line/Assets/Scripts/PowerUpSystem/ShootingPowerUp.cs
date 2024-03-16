using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingPowerUp : MonoBehaviour, IPowerUp
{
    private ShootingComponent _shootingComponent;
    [SerializeField] private bool _bulletStuns;

    public void Apply()
    {
        _shootingComponent.enabled = true;
        _shootingComponent.BulletStuns = _bulletStuns;
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _shootingComponent = collision.gameObject.GetComponentInChildren<ShootingComponent>();
        Apply();
    }
}
