using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthPowerUp : MonoBehaviour, IPowerUp
{
    private HealthComponent _targetHealth;
    [SerializeField] private int _health;

    [SerializeField] UnityEvent powerUPEvent = new UnityEvent();

    public void Apply()
    {
        if (_targetHealth.CurrentHealth != _targetHealth.MaxHealth)
        {
            powerUPEvent.Invoke();
            _targetHealth.Heal(_health);
        }
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HealthComponent healthComponent))
        {
            _targetHealth = healthComponent;
        }
        Apply();
    }
}
