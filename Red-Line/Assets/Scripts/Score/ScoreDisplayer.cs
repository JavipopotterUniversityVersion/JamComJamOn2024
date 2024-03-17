using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class ScoreDisplayer : MonoBehaviour
{
    [SerializeField] Score _score;
    int lastScore;
    [SerializeField] UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    TextMeshProUGUI _text;

    private void Awake() 
    {
        _score.Reset();
        _text = GetComponent<TextMeshProUGUI>();
        _score.OnScoreChangedEvent.AddListener(UpdateScore);
    }

    private void UpdateScore(int score) 
    {
        int scoreDifference = score - lastScore;
        if(scoreDifference > 1) OnScoreChanged.Invoke(scoreDifference);

        lastScore = score;
        _text.text = score.ToString("D4");
    }

    private void OnDestroy() 
    {
        _score.OnScoreChangedEvent.RemoveListener(UpdateScore);
    }
}
