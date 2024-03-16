using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolTaker))]
public class PoolOnEnable : MonoBehaviour
{
    PoolTaker poolTaker;
    [SerializeField] GameObject prefab;

    private void Awake() {
        poolTaker = GetComponent<PoolTaker>();
    }

    private void OnEnable() {
        poolTaker.TakeFromPool(prefab);
    }
}
