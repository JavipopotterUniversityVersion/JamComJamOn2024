using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnEnable : MonoBehaviour
{
    ParticleSystem _particleSystem;

    private void Awake() {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void OnEnable() {
        _particleSystem.Play();
    }
}
