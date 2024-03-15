using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootParableBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField]
    GameObject _whatToShoot;

    Transform _myTransform;
    public void ExecuteBehaviour()
    {
        Shoot();
    }

    private void Shoot()
    {
        GameObject objetico = 
        Instantiate(_whatToShoot, _myTransform.position, Quaternion.identity);

        objetico.GetComponent<ParableBulletComponent>().SetDirection(new Vector3(1,1,0));
    }

    private void Awake()
    {
        _myTransform = transform;
    }
}
