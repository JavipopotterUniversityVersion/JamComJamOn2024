using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockComponent : MonoBehaviour
{
    [SerializeField] float velocityDivider = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.name);
        if (collision.GetComponent<MovementStopper>() != null && collision.TryGetComponent<Rigidbody2D>(out Rigidbody2D a))
        {
            if(velocityDivider != 0)
            a.velocity = a.velocity / velocityDivider;

            Destroy(gameObject);
        }

        else if (collision.TryGetComponent<DamageOnTrigger>(out DamageOnTrigger xd))
        {
            if (velocityDivider != 0)
            xd.GetComponentInParent<Rigidbody2D>().velocity = xd.GetComponentInParent<Rigidbody2D>().velocity / velocityDivider;
            Destroy (gameObject);
        }
    }
}
