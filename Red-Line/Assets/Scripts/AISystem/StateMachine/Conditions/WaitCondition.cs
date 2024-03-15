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
        else return true;
    }

    private void Start()
    {
        gameObject.name = "Wait "+ _waitTime + " sCondition";
    }

}