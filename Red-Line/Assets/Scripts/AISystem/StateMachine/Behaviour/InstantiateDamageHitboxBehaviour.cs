using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateDamageCircleBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField]
    float _explosionRadius = 1.0f;

    [SerializeField]
    LayerMask _whatLayerToDetect;

    private Transform _myTransform;

    bool _hit = false;

    [SerializeField] private int _damage = 1;
    public void ExecuteBehaviour()
    {
        Collider2D player = Physics2D.OverlapCircle(_myTransform.position, _explosionRadius, _whatLayerToDetect);
        if(player != null)
        {
            if (player.gameObject.TryGetComponent(out HealthComponent healthComponent) && !_hit)
            {
                _hit = true;
                healthComponent.Damage(_damage);
            }
        }
    }

    private void Awake()
    {
        _myTransform = transform;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }

}
