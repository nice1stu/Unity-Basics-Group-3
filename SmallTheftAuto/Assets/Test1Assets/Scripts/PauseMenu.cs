using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test1Assets.Scripts
{
    public class PauseMenu : MonoBehaviour
    {
        private static bool GamePaused;
        public GameObject pauseMenuUI;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GamePaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }

            void Resume()
            {
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GamePaused = false;
            }

            void Pause()
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GamePaused = true;
            }

            void LoadMenu()
            {
                Debug.Log("Load Game ...");
            }

            void QuitGame()
            {
                Debug.Log("Thanks for playing");
            }
        }
    }
}
