using ProceduralGenerationSystem.Test;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralGenerationSystem.BackgroundMovement;

namespace ProceduralGenerationSystem.SpawnDespawn
{
    internal class OverTimeSpawnerActivator : MonoBehaviour
    {
        [SerializeField] QueuedRoomSpawner _spawner;
        [SerializeField] TestSpeedProviderObject _speedProvider;

        [SerializeField] private float _parallaxFactor;
        [SerializeField] private float _secondsUntilNextSpawn;

        private void Start ()
        {
            StartCoroutine(SpawnLoop());
        }

        private void SpawnRoom()
        {
            ConstantMovementApplier movement = _spawner.InstantiateNewRoom().GetComponent<ConstantMovementApplier>();
            movement.ParallaxFactor = _parallaxFactor;
        }

        private IEnumerator SpawnLoop()
        {
            while (true)
            {
                SpawnRoom();
                yield return new WaitForSeconds(_secondsUntilNextSpawn / _speedProvider.Speed * _parallaxFactor);
            }
        }
    }
}

