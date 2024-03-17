using UnityEngine;
using UnityEngine.InputSystem;

namespace InputSystem
{
    internal class PauseInput : MonoBehaviour
    {
        [SerializeField] private InputActionReference _pauseInputActionReference;
        [SerializeField] private PauseRequesterObject _pauseRequester;
        [SerializeField] private GameObject _settingsPanel;

        [SerializeField] private InputActionAsset _playerInput;

        private bool _isGamePaused = false;

        private void Awake() {

            _pauseInputActionReference.action.performed += OnPausedInputStarted;
            _pauseRequester.RequestResume();

        }

        private void OnPausedInputStarted(InputAction.CallbackContext obj) {

            if (Time.timeScale == 1)
            {
                SwitchPause();
            }
            if(Time.timeScale == 0)
            {
                _isGamePaused = false;
            }
            print(_isGamePaused);
        }

        public void SwitchPause() {
            _isGamePaused = !_isGamePaused;
            _settingsPanel.SetActive(_isGamePaused);


            //if (_isGamePaused) _pauseRequester.RequestPause();
            //else _pauseRequester.RequestResume();

            if (_isGamePaused)
            {
                Time.timeScale = 0;
                _playerInput.Disable();
            }
            else
            {
                Time.timeScale = 1;
                _playerInput.Enable();
            }
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