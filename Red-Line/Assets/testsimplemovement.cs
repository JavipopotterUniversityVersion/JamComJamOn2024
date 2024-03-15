using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testsimplemovement : MonoBehaviour
{
    private float _speed = 1.0f;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector3 (_speed,0,0);
    }
}
