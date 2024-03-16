using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParableBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField]
    GameObject _whatToShoot;

    [SerializeField]
    float maxRange = 1;

    [SerializeField]
    float height = 1.0f;

    Transform _myTransform;
    public void ExecuteBehaviour()
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject objetico = 
        Instantiate(_whatToShoot, _myTransform.position, Quaternion.identity);
        objetico.GetComponent<ParableBulletComponent>().SetDirection(new Vector3(_myTransform.position.x + UnityEngine.Random.Range(-maxRange, maxRange), height, 0));


    }

    private void Awake()
    {
        _myTransform = transform;
    }
}
