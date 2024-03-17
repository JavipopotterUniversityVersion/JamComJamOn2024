using System.Collections;
using System.Collections.Generic;
using ProceduralGenerationSystem.Test;
using UnityEngine;

public class ScoreUpdaterByGameSpeed : MonoBehaviour
{
    [SerializeField] TestSpeedProviderObject _speedProvider;
    [SerializeField] Score _score;
    int lastScore = 0;
    [SerializeField] float maxSpeed = 15;
    private void Awake() 
    {
        _speedProvider.Speed = 1;
        _score.OnScoreChangedEvent.AddListener(OnScoreChanged);
        StartCoroutine(SpeedUpdate());
    }

    private void Update() {
        if(_speedProvider.Speed < maxSpeed) _speedProvider.Speed += Time.deltaTime / (_speedProvider.Speed * 2);
    }

    IEnumerator SpeedUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _speedProvider.Speed);
            _score.AddScore(1);
        }
    }

    void OnScoreChanged(int score)
    {
        int scoreDifference = score - lastScore;

        if(scoreDifference > 9)
        {
            _score.scoreMultiplier++;
            StopCoroutine(MultiplierUpdate());
            StartCoroutine(MultiplierUpdate());
        }
    }

    IEnumerator MultiplierUpdate()
    {
        yield return new WaitForSeconds(2);
        _score.scoreMultiplier = 1;
    }

    private void OnDestroy() 
    {
        StopCoroutine(SpeedUpdate());
        _score.OnScoreChangedEvent.RemoveListener(OnScoreChanged);
    }
}
