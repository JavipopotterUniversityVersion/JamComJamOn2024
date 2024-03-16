using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParableBulletComponent : MonoBehaviour
{
    private Transform _myTransform;

    [SerializeField]
    private float _downForce = 2;

    [SerializeField]
    private Vector3 _direction;

    [SerializeField]
    private int _damage = 0;

    private void Update()
    {
        _direction = new Vector3(_direction.x, _direction.y - _downForce*Time.deltaTime, _direction.z);

        _myTransform.position = _myTransform.position + _direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MovementStopper>() != null && collision.TryGetComponent<HealthComponent>(out HealthComponent a))
        {
            a.Damage(_damage);
        }
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void Awake()
    {
        _myTransform = transform;
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }
}
