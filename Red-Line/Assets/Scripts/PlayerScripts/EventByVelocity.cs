using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventByVelocity : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] VelocityEvent[] velocityEvents;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        foreach(VelocityEvent velocityEvent in velocityEvents)
        {
            if(rb.velocity.magnitude > velocityEvent.MinVelocity)
            {
                if(!velocityEvent.OnHighVelocityTriggered)
                {
                    velocityEvent.OnHighVelocity.Invoke();
                    velocityEvent.OnHighVelocityTriggered = true;
                }
            }
            else
            {
                if(velocityEvent.OnHighVelocityTriggered)
                {
                    velocityEvent.OnLowVelocity.Invoke();
                    velocityEvent.OnHighVelocityTriggered = false;
                }
            }
        }
    }
}

[System.Serializable]
public class VelocityEvent
{
    [SerializeField] UnityEvent onHighVelocity = new UnityEvent();
    public UnityEvent OnHighVelocity => onHighVelocity;

    [SerializeField] UnityEvent onLowVelocity = new UnityEvent();
    public UnityEvent OnLowVelocity => onLowVelocity;

    bool onHighVelocityTriggered = false;
    public bool OnHighVelocityTriggered { get => onHighVelocityTriggered; set => onHighVelocityTriggered = value; }

    [SerializeField] float minVelocity = 25f;
    public float MinVelocity => minVelocity;
}
