using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundOnTrigger : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] float reboundForce = 10;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            if(other.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = Vector2.zero;
                rb.AddForce((other.transform.position - transform.position).normalized * reboundForce, ForceMode2D.Impulse);
            }
        }
    }
}
