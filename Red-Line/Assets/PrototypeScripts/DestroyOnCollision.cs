using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] UnityEvent onCollide;
    private void OnTriggerEnter2D(Collider2D other) {
        if(targetLayer == (targetLayer | (1 << other.gameObject.layer)))
        {
            onCollide?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
