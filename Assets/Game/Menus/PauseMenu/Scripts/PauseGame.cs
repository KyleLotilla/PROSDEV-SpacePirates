using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Menus.PauseMenu
{
    public class PauseGame : MonoBehaviour
    {
        private bool isInAnotherMenu;
        [SerializeField]
        private GameObject pauseMenuPanel;
        [SerializeField]
        private GameEvent gamePaused;
        [SerializeField]
        private GameEvent gameResumed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isInAnotherMenu)
                {
                    if (pauseMenuPanel.activeSelf)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                    }
                }
            }
        }

        public void Resume()
        {
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1;
            gameResumed.Raise();
        }

        public void Pause()
        {
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
            gamePaused.Raise();
        }

        public void Quit()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Main Menu");
        }

        public void OnAnotherMenuEnter()
        {
            isInAnotherMenu = true;
            if (pauseMenuPanel.activeSelf)
            {
                pauseMenuPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
}

