using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    private void OnEnable() 
    {
        StartCoroutine(waitAndRandomizeRotation());
    }

    IEnumerator waitAndRandomizeRotation()
    {
        yield return new WaitForEndOfFrame();
        RandomizeRotation();
    }

    public void RandomizeRotation() 
    {
        transform.Rotate(0, 0, Random.Range(0f, 360f));
    }
}
