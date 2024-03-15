using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private int _currentHealth = 1;

    [SerializeField]
    private UnityEvent _dieEvent;

    public void Damage(int damageNum)
    {
        _currentHealth = _currentHealth - damageNum;

        if (_currentHealth <= 0)
        {
            _dieEvent.Invoke();
        }
    }

    public void Heal(int healNum)
    {
        _currentHealth += healNum;
        if ( _currentHealth > _maxHealth )
        {
            _currentHealth = _maxHealth;
        }
    }

    private void Awake()
    {
        _currentHealth = _maxHealth;
    }
}

