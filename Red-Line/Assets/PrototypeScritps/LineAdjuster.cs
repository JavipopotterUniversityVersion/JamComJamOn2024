using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAdjuster : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPositions(new Vector3[2]{transform.position, endPoint.position});
    }
}
