using ProceduralGenerationSystem.Test;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGenerationSystem.SpawnDespawn
{
    internal class OverTimeSpawnerActivator : MonoBehaviour
    {
        [SerializeField] QueuedRoomSpawner _spawner;
        [SerializeField] TestSpeedProviderObject _speedProvider;

        [SerializeField] private float _secondsUntilNextSpawn;

        private void Start ()
        {
            StartCoroutine(SpawnLoop());
        }

        private void SpawnRoom()
        {
            Debug.Log(_spawner);
            _spawner.InstantiateNewRoom();
        }

        private IEnumerator SpawnLoop()
        {
            while (true)
            {
                SpawnRoom();
                yield return new WaitForSeconds(_secondsUntilNextSpawn / _speedProvider.Speed);
            }
        }
    }
}

