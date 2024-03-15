using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMeBehaviour : MonoBehaviour, IBehaviour
{
    [SerializeField]
    GameObject fokingObjectToDestroy;
    public void ExecuteBehaviour()
    {
        Destroy(fokingObjectToDestroy);
    }
}
