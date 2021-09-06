using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.Scoring;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Menus.MainMenu
{
    public class StartGame : MonoBehaviour
    {
        [SerializeField]
        private Image black;
        [SerializeField]
        private Animator anim;
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private Level.Level initialLevel;
        [SerializeField]
        private Score score;
        [SerializeField]
        private IntVariable currentPlayerHealth;

        public void StartGameplay()
        {
            currentLevel.Value = initialLevel;
            score.ResetScore();
            currentPlayerHealth.ResetToDefaultValue();
            StartCoroutine(Fading());
        }

        IEnumerator Fading()
        {
            anim.SetBool("Fade", true);
            yield return new WaitUntil(() => black.color.a == 1);
            SceneManager.LoadScene("Gameplay");
        }
    }
}

