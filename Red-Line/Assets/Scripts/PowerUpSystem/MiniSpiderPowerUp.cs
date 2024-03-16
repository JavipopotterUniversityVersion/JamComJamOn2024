using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSpiderPowerUp : MonoBehaviour, IPowerUp
{
    [SerializeField] private GameObject _spiderPrefab;
    [SerializeField] private Transform _spawmTransform;
    public void Apply()
    {
        Instantiate(_spiderPrefab, _spawmTransform);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _spawmTransform = collision.gameObject.transform;
    }
}
