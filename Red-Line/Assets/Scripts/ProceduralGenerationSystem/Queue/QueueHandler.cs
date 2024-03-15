using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProceduralGenerationSystem.Queue
{
    internal class QueueHandler : MonoBehaviour
    {
        [SerializeField] private int _numberOfRooms, _queueLength;

        private GameObject[] _rooms; 
        private Queue<GameObject> _roomQueue;

        private void Awake()
        {
            _rooms = Resources.LoadAll<GameObject>("Rooms");
            _roomQueue = new Queue<GameObject>();

            for (int i = 0; i < _queueLength; i++) EnqueueNewRoom();
        }

        private void EnqueueNewRoom()
        {
            GameObject room;
            do
            {
                room = _rooms[Random.Range(0, _numberOfRooms)];
            } 
            while (_roomQueue.Contains(room));

            _roomQueue.Enqueue(room);
        }

        public GameObject UpdateQueue()
        {
            EnqueueNewRoom();   
            return _roomQueue.Dequeue();
        }
    }
}

