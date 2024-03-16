using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitCondition : MonoBehaviour, ICondition
{
    [SerializeField]
    private float _waitTime = 1f;
    private float _currentTime = 0f;
    public bool CheckCondition()
    {
        if (_currentTime < _waitTime)
        {
            _currentTime = _currentTime + Time.deltaTime;
            return false;
        }
        else
        {
            _currentTime = 0;
            return true;
        }
    }

    private void OnValidate()
    {
        gameObject.name = "Wait "+ _waitTime + " sCondition";
    }

}
