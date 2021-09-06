using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.Scoring;
using TMPro;
using UnityEngine.SceneManagement;

namespace DLSU.SpacePirates.Menus.LevelComplete
{
    public class LevelCompleteMenu : MonoBehaviour
    {
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private Score score;
        [SerializeField]
        private GameObject levelCompletePanel;
        [SerializeField]
        private GameObject gameCompletePanel;
        [SerializeField]
        private TextMeshProUGUI scoreText;
        [SerializeField]
        private TextMeshProUGUI highScoreText;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnLevelComplete()
        {
            if (currentLevel.Value.NextLevel != null)
            {
                DisplayLevelComplete();
            }
            else
            {
                DisplayGameComplete();
            }
        }

        public void DisplayLevelComplete()
        {
            levelCompletePanel.SetActive(true);
        }

        public void DisplayGameComplete()
        {
            UpdateScore();
            gameCompletePanel.SetActive(true);
        }

        public void UpdateScore()
        {
            scoreText.text = score.CurrentScore.ToString();
            if (score.IsNewHighScore)
            {
                score.SaveNewHighScore();
            }
            highScoreText.text = score.HighScore.ToString();
        }

        public void ContinueToNextLevel()
        {
            currentLevel.Value = currentLevel.Value.NextLevel;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Quit()
        {
            SceneManager.LoadScene("Main Menu");
        }

    }
}

