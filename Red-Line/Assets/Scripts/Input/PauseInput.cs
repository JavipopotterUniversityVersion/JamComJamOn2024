using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    internal class PauseInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference _pauseInputActionReference;
        [SerializeField] private PauseRequesterObject _pauseRequester;
        [SerializeField] private GameObject _HUDPanel;
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
            //_HUDPanel.SetActive(!_isGamePaused);
            _settingsPanel.SetActive(_isGamePaused);

            if (_isGamePaused) _pauseRequester.RequestPause();
            else _pauseRequester.RequestResume();
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