using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenThrower : MonoBehaviour
{
    Vector2[] initialLocalPositions;
    private void Awake() {
        initialLocalPositions = new Vector2[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            initialLocalPositions[i] = transform.GetChild(i).localPosition;
        }
    }
    private void OnEnable() {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = initialLocalPositions[i];

            float randomAngle = Random.Range(0, 360);
            Vector2 randomDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));

            transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = randomDirection * Random.Range(5, 10);
        }
    }
}
