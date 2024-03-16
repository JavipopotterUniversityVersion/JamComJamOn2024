using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] PoolObject[] poolObjects;
    public Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake() {
        foreach (PoolObject poolObject in poolObjects)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < poolObject.size; i++)
            {
                GameObject obj = Instantiate(poolObject.prefab[Random.Range(0, poolObject.prefab.Length)]);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(poolObject.prefab[0], objectPool);
        }
    }


    public GameObject SpawnFromPool(Vector2 position, Quaternion rotation, GameObject prefab)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[prefab].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[prefab].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}

[System.Serializable]
public class PoolObject
{
    public GameObject[] prefab;
    public int size;
}
