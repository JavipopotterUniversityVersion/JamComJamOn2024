using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstanceOnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] prefabs;
    
    private void Awake() {
        Spawn(transform.position);
    }
    
    public void Spawn(Vector3 position)
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], position, Quaternion.identity);
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
