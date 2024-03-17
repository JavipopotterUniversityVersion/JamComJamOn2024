using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPlayerBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField]
    private float _detectionRadius;

    [SerializeField]
    LayerMask _whatLayerToDetect;

    [SerializeField]
    float _speed = 1;

    [SerializeField]
    int _damage = 1;

    [SerializeField]
    Transform parentTransform;
    bool _gotDirection;
    Vector3 _direction;
    public void ExecuteBehaviour()
    {
        if(!_gotDirection)
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, _detectionRadius, _whatLayerToDetect.value);
            if (collider != null)
            {
                _direction = (collider.transform.position - transform.position).normalized;
                _gotDirection = true;

               parentTransform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg);
                
            }
        }

        parentTransform.position = parentTransform.position + _direction * Time.deltaTime * _speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MovementStopper>() != null && collision.TryGetComponent<HealthComponent>(out HealthComponent a))
        {
            a.Damage(_damage);
            Destroy(parentTransform.gameObject);
        }
    }
}
