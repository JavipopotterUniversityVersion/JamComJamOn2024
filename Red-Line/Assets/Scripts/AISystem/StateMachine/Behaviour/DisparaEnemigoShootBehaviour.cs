using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaEnemigoShootBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField]
    GameObject _bulletPrefab;

    Transform _myTransform;
    public void ExecuteBehaviour()
    {
        GameObject[] currentBullets = new GameObject[4];

        for (int i =0; i < currentBullets.Length; i++)
        {
            currentBullets[i] = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }

        currentBullets[0].GetComponent<bulletDisparaEnemigoComponent>().SetDirection(new Vector2 (1,1));
        currentBullets[1].GetComponent<bulletDisparaEnemigoComponent>().SetDirection(new Vector2(1, -1));
        currentBullets[2].GetComponent<bulletDisparaEnemigoComponent>().SetDirection(new Vector2(-1, -1));
        currentBullets[3].GetComponent<bulletDisparaEnemigoComponent>().SetDirection(new Vector2(-1, 1));
    }
    private void Awake()
    {
        _myTransform = transform;
    }
}
