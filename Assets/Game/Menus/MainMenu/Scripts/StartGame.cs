using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DLSU.SpacePirates.Level;
using DLSU.SpacePirates.Scoring;

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

        public void StartGameplay()
        {
            currentLevel.Value = initialLevel;
            score.ResetScore();
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

