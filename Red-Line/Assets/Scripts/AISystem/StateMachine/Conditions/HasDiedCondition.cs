using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasDiedCondition : MonoBehaviour, ICondition
{
    private bool hasDied = false;
    public bool CheckCondition()
    {
        return hasDied;
    }

    public void Die()
    {
        hasDied = true;
    }
}
