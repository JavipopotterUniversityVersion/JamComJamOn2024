using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    [SerializeField] private float _minScale, _maxScale;

    private void OnEnable() => RandomizeScale();

    public void RandomizeScale() 
    {
        float scale = Random.Range(_minScale, _maxScale);
        transform.localScale = new Vector3(scale, scale, scale);
    }
}
