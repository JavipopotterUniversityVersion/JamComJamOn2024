using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstanceOnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    
    private void Awake() {
        Spawn(transform);
    }
    
    public void Spawn(Transform transform)
    {
        Transform transform1 = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform).transform;
        // transform1.SetParent(null);
        // transform1.localScale = Vector3.one;
        // transform1.SetParent(transform);
    }

    private void OnValidate() {
        if(prefabs.Length > 0)
        {
            string nameSum = "";

            foreach (var item in prefabs)
            {
                nameSum += "-" + item.name + $"\n";
            }

            name = $"Random: \n" + nameSum;
        }
    }
}
