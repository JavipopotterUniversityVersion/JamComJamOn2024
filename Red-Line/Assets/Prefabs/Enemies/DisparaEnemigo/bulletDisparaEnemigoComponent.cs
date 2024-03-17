using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDisparaEnemigoComponent : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] float _speed = 1;
    private Transform _myTransform;
    [SerializeField] int _damage;
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
        StartCoroutine(MuerePuta());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MovementStopper>() != null && collision.TryGetComponent<HealthComponent>(out HealthComponent a))
        {
            a.Damage(_damage);
            Destroy(gameObject);
        }
    }

    IEnumerator MuerePuta()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
