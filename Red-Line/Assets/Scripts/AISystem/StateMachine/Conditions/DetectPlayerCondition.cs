using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCondition : MonoBehaviour, ICondition
{
    [SerializeField]
    float _detectionRadius = 1.0f;

    [SerializeField]
    LayerMask _whatLayerToDetect;

    private Transform _myTransform;

    public bool CheckCondition()
    {
        return (Physics2D.OverlapCircle(_myTransform.position, _detectionRadius, _whatLayerToDetect.value) != null);
    }

    private void Awake()
    {
        _myTransform = transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }

}
