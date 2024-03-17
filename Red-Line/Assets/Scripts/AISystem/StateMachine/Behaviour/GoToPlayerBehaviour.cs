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

    bool destroying = false;


    [SerializeField]
    Transform parentTransform;
    Vector3 _direction;
    Rigidbody2D rb;

    [Range(0,1)]
    [SerializeField]
    float _weight;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    public void ExecuteBehaviour()
    {
        if (!destroying) StartCoroutine(DestroyMe());
        Collider2D collider = Physics2D.OverlapCircle(transform.position, _detectionRadius, _whatLayerToDetect.value);
        if (collider != null)
        {
            _direction = (collider.transform.position - transform.position).normalized;
            
            
        }

        rb.velocity = Vector2.Lerp(rb.velocity.normalized, _direction, Time.deltaTime * _weight) * _speed;

        parentTransform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(-rb.velocity.normalized.x, -rb.velocity.normalized.y) * Mathf.Rad2Deg);
    }

    IEnumerator DestroyMe()
    {
        destroying = true;
        yield return new WaitForSeconds(3);
        Destroy(rb.gameObject);
    }
}
