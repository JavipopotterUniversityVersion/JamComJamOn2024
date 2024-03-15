using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenusSystem {
    internal class ChangeScene : MonoBehaviour
    {
        [SerializeField]
        private SceneSettings _sceneSettings;

        public void SceneChange(string scene)
        {
            SceneManager.LoadScene(scene);

            _sceneSettings.CheckFullScreen();


        }
    }
}