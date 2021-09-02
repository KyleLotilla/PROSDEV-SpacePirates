using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DLSU.SpacePirates.Scoring;

namespace DLSU.SpacePirates.Scoring
{
    public class ScoreHUD : MonoBehaviour
    {
        [SerializeField]
        private Score score;
        [SerializeField]
        private TextMeshProUGUI scoreText;

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnScoreChanged()
        {
            scoreText.text = score.CurrentScore.ToString();
        }
    }
}

