using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetREsolutionOnStart : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1600, 900, true);
    }
}
