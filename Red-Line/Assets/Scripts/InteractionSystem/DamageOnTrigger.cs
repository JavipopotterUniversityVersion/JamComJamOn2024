using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            if(other.TryGetComponent(out HealthComponent healthComponent))
            {
                healthComponent.Damage(damageAmount);
            }
        }
    }
}
