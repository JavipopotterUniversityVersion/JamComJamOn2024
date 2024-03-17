using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LifeContainer", menuName = "UI/LifeContainer")]
public class LifeContainer : ScriptableObject
{
    int lives = 3;

    UnityEvent<int> onLivesChange = new UnityEvent<int>();
    public UnityEvent<int> OnLivesChange => onLivesChange;

    public int Lives
    {
        get => lives;
        set
        {
            lives = value;
            onLivesChange.Invoke(lives);
        }
    }
    
    public void SetLives(int value) => Lives = value;
}
