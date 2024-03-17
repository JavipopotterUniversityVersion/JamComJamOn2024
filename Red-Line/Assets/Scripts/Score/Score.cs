using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 1)]
public class Score : ScriptableObject
{
    [SerializeField] private int _score;
    public int score 
    {
        get => _score;
        private set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }

    public int scoreMultiplier = 1;

    UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnScoreChangedEvent => OnScoreChanged;

    public void Reset() => score = 0;

    public void AddScore(int amount) => score += amount * scoreMultiplier;
}
