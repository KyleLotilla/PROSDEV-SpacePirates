using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DLSU.SpacePirates.Scoring;
using TMPro;

namespace DLSU.SpacePirates.Menus
{
    public class GameOverHUD : MonoBehaviour
    {
        [SerializeField]
        private Score score;
        [SerializeField]
        private TextMeshProUGUI scoreText;
        [SerializeField]
        private TextMeshProUGUI highScoreText;

        public void UpdateScore()
        {
            scoreText.text = score.CurrentScore.ToString();
            if (score.IsNewHighScore)
            {
                score.SaveNewHighScore();
            }
            highScoreText.text = score.HighScore.ToString();
        }

        // Start is called before the first frame update
        public void Quit()
        {
            //SceneManager.LoadScene("Main Menu");
            Application.Quit();
        }

        // Update is called once per frame
        public void Retry()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}


