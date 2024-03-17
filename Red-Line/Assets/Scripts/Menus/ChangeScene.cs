using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenusSystem {
    internal class ChangeScene : MonoBehaviour
    {

        public void SceneChange(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}