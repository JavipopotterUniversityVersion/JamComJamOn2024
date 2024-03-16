using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvokeEventBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField] UnityEvent behaviourEvent = new UnityEvent();
    public UnityEvent BehaviourEvent => behaviourEvent;

    public void ExecuteBehaviour()
    {
        behaviourEvent?.Invoke();
    }
}
