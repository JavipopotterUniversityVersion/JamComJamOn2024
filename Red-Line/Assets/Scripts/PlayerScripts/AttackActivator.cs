using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackActivator : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float minVelocity = 50f;

    Collider2D thisCollider;
    Collider2D attackCollider;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();

        thisCollider = GetComponent<Collider2D>();

        foreach(Collider2D collider in GetComponentsInChildren<Collider2D>())
        {
            if(collider != thisCollider)
            {
                attackCollider = collider;
            }
        }
    }

    private void Update() {
        if(rb.velocity.magnitude > minVelocity)
        {
            thisCollider.enabled = false;
            attackCollider.gameObject.SetActive(true);
        }
        else
        {
            thisCollider.enabled = true;
            attackCollider.gameObject.SetActive(false);
        }
    }
}
