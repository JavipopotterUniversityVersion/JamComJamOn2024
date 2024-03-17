using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaxScore", menuName = "MaxScore")]
public class MaxScore : ScriptableObject
{
    [SerializeField] private Score _score;

    private int _maxScore = 0;

    public int maxScore { get => _maxScore; set => _maxScore = value; }

    public void CheckMaxScore()
    {
        if(_score.score > _maxScore)
        {
            _maxScore = _score.score; 
        }
    }

}
