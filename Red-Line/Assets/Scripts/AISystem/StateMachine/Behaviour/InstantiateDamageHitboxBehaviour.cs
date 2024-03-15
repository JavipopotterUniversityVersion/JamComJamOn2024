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
        Collider2D player = Physics2D.OverlapCircle(transform.position, _explosionRadius, _whatLayerToDetect.value);

        if (player != null &&!_hit)
        {
            _hit = true;
            player.gameObject.GetComponent<HealthComponent>().Damage(_damage);
        }
    }


}
