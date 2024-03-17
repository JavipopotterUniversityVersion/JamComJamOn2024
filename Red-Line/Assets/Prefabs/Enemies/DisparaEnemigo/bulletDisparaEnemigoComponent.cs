using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDisparaEnemigoComponent : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] float _speed = 1;
    private Transform _myTransform;
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        _myTransform.position = (Vector2)_myTransform.position + _direction * _speed * Time.deltaTime;
    }

    private void Awake()
    {
        _myTransform = transform;
    }

}
