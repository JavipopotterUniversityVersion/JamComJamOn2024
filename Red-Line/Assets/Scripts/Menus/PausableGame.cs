using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MenusSystem
{
    public class PausableGame : MonoBehaviour
    {
        [SerializeField]
        private PauseRequesterObject _requesterObject;

        public void GamePause()
        {
            if(_requesterObject.IsPaused)
            {
                Time.timeScale = 0;
            }
            else
            { 
               Time.timeScale = 1;
            }
        }

    }
}