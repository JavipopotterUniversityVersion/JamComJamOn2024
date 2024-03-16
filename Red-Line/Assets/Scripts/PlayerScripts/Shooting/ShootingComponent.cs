using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    private bool _bulletStuns;

    public bool BulletStuns { get => _bulletStuns; set => _bulletStuns = value; }

    [SerializeField] private GameObject _stunningBullet, _poisonBullet;
    [SerializeField] private Rigidbody2D _snailRB;
    private Transform _myTransform;




    private void Awake()
    {
        _myTransform = transform;
        this.enabled = false;
    }

    public void Shoot()
    {
        
        IBullet bullet;
        if (_bulletStuns) bullet = Instantiate(_stunningBullet, _myTransform.position, Quaternion.identity).GetComponent<IBullet>();
        else bullet = Instantiate(_poisonBullet, _myTransform.position, Quaternion.identity).GetComponent<IBullet>();

        bullet.SetDirection(Vector2.right);
    }
}
