using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    internal class PauseInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference _pauseInputActionReference;
        [SerializeField] private PauseRequesterObject _pauseRequester;
        [SerializeField] private GameObject _settingsPanel;

        private bool _isGamePaused = false;

        private void Awake() {

            _pauseInputActionReference.action.performed += OnPausedInputStarted;
            _pauseRequester.RequestResume();

        }

        private void OnPausedInputStarted(InputAction.CallbackContext obj) {
            SwitchPause();
        }

        public void SwitchPause() {
            _isGamePaused = !_isGamePaused;
            _settingsPanel.SetActive(_isGamePaused);


            //if (_isGamePaused) _pauseRequester.RequestPause();
            //else _pauseRequester.RequestResume();

            if (_isGamePaused) Time.timeScale = 0;
          //  else Time.timeScale = 1;
        }

        #region ENABLE / DISABLE INPUTACTIONS

        private void OnEnable() {
            _pauseInputActionReference.action.Enable();
        }

        private void OnDisable() {
            _pauseInputActionReference.action.Disable();
        }

        #endregion
    }
}