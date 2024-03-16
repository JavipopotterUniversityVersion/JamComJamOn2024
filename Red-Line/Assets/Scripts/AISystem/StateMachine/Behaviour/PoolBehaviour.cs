using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PoolTaker))]
public class PoolBehaviour : MonoBehaviour, IBehaviour
{
    PoolTaker poolTaker;
    [SerializeField] string[] poolTag;

    private void Awake() {
        poolTaker = GetComponent<PoolTaker>();
    }

    public void ExecuteBehaviour()
    {
        foreach(string tag in poolTag)
        {
            poolTaker.TakeFromPool(tag);
        }
    }

    private void OnValidate() {
        string tagCombination = "";

        foreach(string tag in poolTag)
        {
            tagCombination += tag + ", ";
        }

        name = "PoolBehaviour: " + tagCombination;
    }
}
