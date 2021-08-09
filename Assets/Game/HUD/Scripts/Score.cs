using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int numScore = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalscore;
    public TextMeshProUGUI highscore;
    public GameObject player;
    private bool gameover;
    private float timer;

    void Start(){
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player){
            gameover = true;
        }

        timer += Time.deltaTime;
        if (timer > 0.1f && gameover == false)
        { 
            numScore += 1;
            scoreText.text = "" + numScore;
            finalscore.text = "" + numScore;
            timer = 0;
            if(numScore > PlayerPrefs.GetInt("HighScore", 0)){
                PlayerPrefs.SetInt("HighScore", numScore);
                highscore.text = "" + numScore;
            } 
        }
    }

    public void addScore(int points)
    {
        numScore += points;
    }
}
