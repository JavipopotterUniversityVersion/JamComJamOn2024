using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5;
    [SerializeField] float moveRange = 5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        if(transform.position.x > moveRange)
        {
            transform.position = new Vector2(moveRange, transform.position.y);
        }
        else if(transform.position.x < -moveRange)
        {
            transform.position = new Vector2(-moveRange, transform.position.y);
        }
    }

    // Update is called once per frame
    public void Move(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }
}
