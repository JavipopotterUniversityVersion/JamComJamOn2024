using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolTaker))]
public class PoolBehaviour : MonoBehaviour, IBehaviour
{
    PoolTaker poolTaker;
    [SerializeField] GameObject[] prefabs;

    private void Awake() {
        poolTaker = GetComponent<PoolTaker>();
    }

    public void ExecuteBehaviour()
    {
        foreach(GameObject prefab in prefabs)
        {
            poolTaker.TakeFromPool(prefab);
        }
    }

    private void OnValidate() {
        string tagCombination = "";

        foreach(GameObject prefab in prefabs)
        {
            tagCombination += prefab.name + " ";
        }

        name = "PoolBehaviour: " + tagCombination;
    }
}
