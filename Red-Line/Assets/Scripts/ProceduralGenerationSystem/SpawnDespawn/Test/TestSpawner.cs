using ProceduralGenerationSystem.SpawnDespawn;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace ProceduralGenerationSystem.SpawnDespawn.Test
{
    public class TestSpawner : MonoBehaviour
    {
        [SerializeField] QueuedRoomSpawner _roomSpawner;

        [ContextMenu(nameof(SpawnOneRoom))]
        private void SpawnOneRoom()
        {
            _roomSpawner.InstantiateNewRoom();
        }

    }
}

