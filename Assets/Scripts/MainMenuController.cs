using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace DontWannaDie
{
    public class MainMenuController : MonoBehaviour
    {
        #region Methods

        public void StartButtonPresed()
        {
            SceneManager.LoadScene(1);
        }

        #endregion
    }
}

