using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UIElements
{
    public class PauseMenu : MonoBehaviour
    {
        /// <summary>
        ///  This bool helps to trigger functions.
        /// </summary>
        public static bool isPaused = false;

        public GameObject pausemenuUI;

        /// <summary>
        /// This Update method will be checked in every frame for the bool!
        /// </summary>
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = true;
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }

        /// <summary>
        /// Will resume the game and disable the menu nothing crazy here
        /// </summary>
        public void Resume()
        {
            pausemenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        /// <summary>
        /// This is called once the bool is true!
        /// </summary>
        void Pause()
        {
            pausemenuUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
        }
        
        /// <summary>
        /// though this is gonna cause a bug, why cause it will null everything on the next time you load the scene
        /// </summary>
        public void LoadMenu() 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
        /// <summary>
        /// Will literally load the scene you are in currently.
        /// </summary>
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitGame()
        {
            // Quits game in build
            Application.Quit();
            // Quits play mode in editor
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }
}