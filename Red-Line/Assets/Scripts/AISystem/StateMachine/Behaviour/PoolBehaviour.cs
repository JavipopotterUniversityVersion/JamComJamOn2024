using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolTaker))]
public class PoolBehaviour : MonoBehaviour, IBehaviour
{
    PoolTaker poolTaker;
    [SerializeField] string poolTag;

    private void Awake() {
        poolTaker = GetComponent<PoolTaker>();
    }

    public void ExecuteBehaviour()
    {
        poolTaker.TakeFromPool(poolTag);
    }

    private void OnValidate() {
        name = "Take " + poolTag;
    }
}
