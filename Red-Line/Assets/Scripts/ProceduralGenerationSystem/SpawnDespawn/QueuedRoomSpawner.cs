using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralGenerationSystem.Queue;

namespace ProceduralGenerationSystem.SpawnDespawn
{
    internal class QueuedRoomSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _roomSpawnPoint;
        [SerializeField] private QueueHandler _queueHandler;

        public void InstantiateNewRoom()
        {
            Instantiate(_queueHandler.UpdateQueue(), _roomSpawnPoint);
        }
    }
}

