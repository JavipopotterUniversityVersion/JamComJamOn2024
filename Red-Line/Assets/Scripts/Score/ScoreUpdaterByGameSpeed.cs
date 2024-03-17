using System.Collections;
using System.Collections.Generic;
using ProceduralGenerationSystem.Test;
using UnityEngine;

public class ScoreUpdaterByGameSpeed : MonoBehaviour
{
    [SerializeField] TestSpeedProviderObject _speedProvider;
    [SerializeField] Score _score;
    [SerializeField] float maxSpeed = 10;
    private void Awake() 
    {
        _speedProvider.Speed = 1;
        StartCoroutine(SpeedUpdate());
    }

    private void Update() {
        _speedProvider.Speed += Time.deltaTime / (_speedProvider.Speed * 2);
    }

    IEnumerator SpeedUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / _speedProvider.Speed);
            _score.AddScore(1);
        }
    }

    private void OnDestroy() 
    {
        StopCoroutine(SpeedUpdate());
    }
}
