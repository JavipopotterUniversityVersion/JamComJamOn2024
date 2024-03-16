using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunningBullet : MonoBehaviour, IBullet
{
    [SerializeField] private float _speed;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //stunea
        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
       _direction = direction;
    }
}
