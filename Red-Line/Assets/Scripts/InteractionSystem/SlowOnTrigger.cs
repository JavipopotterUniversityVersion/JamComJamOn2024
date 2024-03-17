using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowOnTrigger : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;

    private void OnTriggerEnter(Collider other) 
    {
        if (targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            if(other.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity /= 2;
            }
        }
    }
}
