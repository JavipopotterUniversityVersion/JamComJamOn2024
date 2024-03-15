using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParableBulletComponent : MonoBehaviour
{
    private Vector3 _direction = Vector2.zero;

    private Rigidbody2D _rb;

    private bool hasHit = false;

    [SerializeField] int _damage = 1;

    [SerializeField] private float yDecreasing;

    private void Update()
    {
        _direction.y = _direction.y - yDecreasing;

        _rb.MovePosition(_rb.transform.position + _direction * Time.deltaTime);
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthComponent>(out HealthComponent component) && !hasHit)
        {
            hasHit = true;
            component.Damage(_damage);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
