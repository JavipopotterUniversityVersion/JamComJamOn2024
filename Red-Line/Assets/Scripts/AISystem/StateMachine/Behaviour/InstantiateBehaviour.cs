using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] GameObject _prefab;
    [SerializeField] Transform _instantiatePosition;
    [SerializeField] float instanceVelocity = 0f;

    private void Awake() {
        if(_instantiatePosition == null)
        {
            _instantiatePosition = transform;
        }
    }

    public void ExecuteBehaviour()
    {
        GameObject instance = Instantiate(_prefab, _instantiatePosition.position, _instantiatePosition.rotation);

        if(instance.TryGetComponent(out Rigidbody2D rb))
        {
            rb.velocity = _instantiatePosition.right * instanceVelocity;
        }
    }

    private void OnValidate() {
        name = $"InstantiateBehaviour {_prefab.name}";
    }
}
