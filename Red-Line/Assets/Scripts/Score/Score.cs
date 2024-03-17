using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Score", menuName = "ScriptableObjects/Score", order = 1)]
public class Score : ScriptableObject
{
    [SerializeField] private int _score;
    private bool _playerIsDead = false;
    public int score 
    {
        get => _score;
        private set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }

    public void PlayerHasDied() => _playerIsDead = true;

    public int scoreMultiplier = 1;

    UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    public UnityEvent<int> OnScoreChangedEvent => OnScoreChanged;

    public void Reset() 
    { 
        score = 0; 
        _playerIsDead = false; 
    }

    public void AddScore(int amount)
    {
        if (!_playerIsDead) score += amount * scoreMultiplier;
    }
}
