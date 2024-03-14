using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInstanceOnArea : MonoBehaviour
{
    [SerializeField] Vector2 areaSize;
    [SerializeField] GameObject instancePrefab;
    [SerializeField] Vector2 direction;
    float timer;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, areaSize);
    }

    private void Update() 
    {
        timer += Time.deltaTime;
        float maxTime = Random.Range(3, 6);

        if(timer > maxTime)
        {
            timer = 0;

            for(int i = 0; i < Random.Range(3,5); i++)
            {
                CreateRandomInstance();
            }
        }
    }

    void CreateRandomInstance()
    {
        Vector2 randomPosition = new Vector3(Random.Range(-areaSize.x, areaSize.x), 
        Random.Range(-areaSize.y, areaSize.y));
        Rigidbody2D rb = Instantiate(instancePrefab, (Vector2)transform.position + randomPosition, Quaternion.identity).GetComponent<Rigidbody2D>();
        rb.velocity = direction * Random.Range(3, 6);
    }
}
