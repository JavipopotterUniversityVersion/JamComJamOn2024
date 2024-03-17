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

    [SerializeField]
    private UnityEvent _onTakeDamage;

    


    UnityEvent<int> onLifeChanged = new UnityEvent<int>();
    public UnityEvent<int> OnLifeChanged => onLifeChanged;

    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public int CurrentHealth 
    { 
        get => _currentHealth; 
        set 
        {
            onLifeChanged.Invoke(value);
            _currentHealth = value; 
        }
    }

    public void Damage(int damageNum)
    {
        CurrentHealth = CurrentHealth - damageNum;
        _onTakeDamage?.Invoke();

        if (CurrentHealth <= 0)
        {
            _dieEvent.Invoke();
        }
    }


    public void Heal(int healNum)
    {
        CurrentHealth += healNum;
        if ( CurrentHealth > _maxHealth )
        {
            CurrentHealth = _maxHealth;
        }
    }

    private void Awake()
    {
        CurrentHealth = _maxHealth;
    }
}

