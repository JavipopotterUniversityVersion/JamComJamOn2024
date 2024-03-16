using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ParableBulletComponent : MonoBehaviour, ICondition
{
    private bool _stunned = false;
    private bool startedCoroutine = false;
    public bool CheckCondition()
    {
        return _stunned;
    }

    public void Stun(float seconds)
    {
        if (!startedCoroutine)
        {
            StartCoroutine(ReturnStun(seconds));
        }
    }

    IEnumerator ReturnStun(float seconds)
    {
        startedCoroutine = true;
        _stunned = true;

        yield return new WaitForSeconds(seconds);
        _stunned = true;
        startedCoroutine = false;
    }
}
