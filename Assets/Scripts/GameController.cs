using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace DontWannaDie
{
    public class GameController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private GameObject _onScreenTimer;
        [SerializeField] private GameObject _pauseButton;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _winMenu;
        [SerializeField] private GameObject _looseMenu;

        [SerializeField] private float _levelTime = 180000.0f;

        private float _timeRemaining;
        private float _minutes;
        private float _seconds;

        #endregion

        #region UnityMethods

        private void Start()
        {
            StartCountdown();
        }

        private void Update()
        {
            TimerProcess();
        }

        #endregion

        #region Methods

        public void PauseGame()
        {
            HideUIElement(_pauseButton);
            ShowUIElement(_pauseMenu);
            Time.timeScale = 0;

        }

        public void UnPauseGame()
        {
            HideUIElement(_pauseMenu);
            ShowUIElement(_pauseButton);
            Time.timeScale = 1;
        }

        public void GameExit()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        }

        public void GameOver()
        {
            HideUIElement(_pauseButton);
            HideUIElement(_onScreenTimer);
            ShowUIElement(_looseMenu);
        }

        public void GameWin()
        {
            HideUIElement(_pauseButton);
            HideUIElement(_onScreenTimer);
            Time.timeScale = 0;
            ShowUIElement(_winMenu);
        }

        public void GameRestart()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

        public void GameNexLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(2);
        }

        private void HideUIElement(GameObject UIElement)
        {
            UIElement.SetActive(false);
        }

        private void ShowUIElement(GameObject UIElement)
        {
            UIElement.SetActive(true);
        }

        private void StartCountdown()
        {
            _timeRemaining = _levelTime;
        }

        private void TimerProcess()
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                _timeRemaining = 0;
                GameOver();
            }
            _minutes = Mathf.FloorToInt(_timeRemaining / 60);
            _seconds = Mathf.FloorToInt(_timeRemaining % 60);

            _onScreenTimer.GetComponent<Text>().text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
        }

        #endregion
    }
}

