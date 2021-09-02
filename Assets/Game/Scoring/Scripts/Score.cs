using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Scoring
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Score")]
    public class Score : ScriptableObject
    {
        private int currentScore = 0;
        public int CurrentScore
        {
            get
            {
                return currentScore;
            }
        }
        private int highScore = 0;
        public int HighScore
        {
            get
            {
                return highScore;
            }
        }

        public bool IsNewHighScore
        {
            get
            {
                return currentScore > highScore;
            }
        }

        [SerializeField]
        private GameEvent scoreChanged;

        private void OnEnable()
        {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
            currentScore = 0;
        }

        public void AddScore(int score)
        {
            currentScore += score;
            scoreChanged.Raise();
        }

        public void ResetScore()
        {
            currentScore = 0;
            scoreChanged.Raise();
        }

        public void SaveNewHighScore()
        {
            if (IsNewHighScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }
    }
}

