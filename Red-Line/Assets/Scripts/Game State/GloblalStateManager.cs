using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "GlobalsStateManager", menuName = "Game State/GlobalsStateManager")]
public class GlobalStateManager : ScriptableObject
{
    [SerializeField] UnityEvent onDeathEvent = new UnityEvent();
    public UnityEvent OnDeathEvent => onDeathEvent;

    [SerializeField] UnityEvent onResume = new UnityEvent();
    public UnityEvent OnResume => onResume;

    [SerializeField] UnityEvent onRestart = new UnityEvent();
    public UnityEvent OnRestart => onRestart;

    public void Death()
    {
        Time.timeScale = 0;
        onDeathEvent.Invoke();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        onResume.Invoke();
    }

    public void Restart()
    {
        Resume();
        onRestart.Invoke();
    }
}
