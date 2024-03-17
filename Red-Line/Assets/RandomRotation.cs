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
        transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)));
    }
}
