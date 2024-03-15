using ProceduralGenerationSystem.Test;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGenerationSystem.BackgroundMovement
{
    internal class ConstantMovementApplier : MonoBehaviour
    {
        [SerializeField] private TestSpeedProviderObject _speedProvider;
        [SerializeField] private Vector2 _direction;
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }
        private void Update()
        {
            _transform.position += (Vector3)_direction * _speedProvider.Speed * Time.deltaTime;
        }
    }
}

