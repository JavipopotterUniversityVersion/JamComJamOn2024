using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    [SerializeField] bool randomOnEnable = true;

    private void OnEnable() 
    {
        if (randomOnEnable) 
        {
            RandomizeRotation();
        }
    }

    public void RandomizeRotation() 
    {
        transform.Rotate(0, 0, Random.Range(0f, 360f));
    }
}
