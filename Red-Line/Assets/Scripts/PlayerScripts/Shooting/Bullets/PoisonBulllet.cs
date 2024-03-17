using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PoisonBulllet : MonoBehaviour, IBullet
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private Transform _transform;
    private Vector2 _direction;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        _transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthComponent health = collision.gameObject.GetComponentInChildren<HealthComponent>();

        if (health != null)
        {
            health.Damage(_damage);
            Destroy(gameObject);
        }
    }
}
