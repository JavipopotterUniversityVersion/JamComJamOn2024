using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour, IPowerUp
{
    private HealthComponent _targetHealth;
    [SerializeField] private int _health;
    public void Apply()
    {
        if (_targetHealth.CurrentHealth != _targetHealth.MaxHealth)
        {
            _targetHealth.Heal(_health);
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _targetHealth = collision.gameObject.GetComponentInChildren<HealthComponent>();
        Apply();
    }
}
