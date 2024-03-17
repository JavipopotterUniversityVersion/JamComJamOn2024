using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunningBullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _speed;

    private Transform _transform;
    private Vector2 _direction = Vector2.right;

    [SerializeField]
    private float _stunDuration = 100000;

    private void Awake()
    {
        _transform = transform; 
    }

    private void Update()
    {
        _transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInChildren<StunCondition>().Stun(_stunDuration);
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
       _direction = direction;
    }
}
