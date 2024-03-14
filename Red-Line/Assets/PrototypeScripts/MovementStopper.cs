using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStopper : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float stopVelocity = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Horizontal") == 0)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, stopVelocity * Time.deltaTime);
        }
    }
}
