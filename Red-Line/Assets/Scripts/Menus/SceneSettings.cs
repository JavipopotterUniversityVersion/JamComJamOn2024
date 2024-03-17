using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MenusSystem
{
    internal class SceneSettings : MonoBehaviour
    {

        //sounds
        [SerializeField]
        private Slider _soundSlider;
        [SerializeField]
        private float _soundSliderValue = 0;
        [SerializeField]
        private Image _muteImage;
        [SerializeField]
        private Image _soundImage;

        [SerializeField]
        private InputActionAsset _playerInput;


        //full screen 
        [SerializeField]
        private Toggle _fullScreenToggle;

        private void Awake()
        {
            //sound
            _soundSlider.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
            AudioListener.volume = _soundSlider.value;
            ShowSoundImage();

            //full screen
            
            if(Screen.fullScreen)
            {
                _fullScreenToggle.isOn = true;
            }
            else
            {
                _fullScreenToggle.isOn = false;
            }
        }



        public void ChangeSoundSlider(float value)
        {
            _soundSliderValue = value;
            PlayerPrefs.SetFloat("audioVolume", _soundSliderValue);
            AudioListener.volume = _soundSlider.value;
            ShowSoundImage();

        }

        public bool CheckFullScreen()
        {
            return Screen.fullScreen;
        }

        public void ShowSoundImage()
        {
            if (_soundSliderValue == 0)
            {
                _soundImage.enabled = false;
                _muteImage.enabled = true;
            }

            else
            {
                _muteImage.enabled = false;
                _soundImage.enabled = true;
            }
        }

        public void ActivateFullScreen(bool fullScreen)
        {
            Screen.fullScreen = fullScreen;
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1;
            _playerInput.Enable();

        }

        public void ReloadScene()
        {
            SceneManager.LoadScene("Game");
        }


        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
