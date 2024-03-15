using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGenerationSystem.Test
{
    [CreateAssetMenu(menuName = "Test Speed Provider", fileName = "Test Speed Provider")]
    internal class TestSpeedProviderObject : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
    }
}

