using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProgression : MonoBehaviour
{
    [SerializeField]
    private bool LevelProgression;

    [SerializeField]
    private bool GameEnd;

    [SerializeField]
    private GameOver gameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BossClear()
    {
        if (LevelProgression)
        {

        }

        else if (GameEnd)
        {
            gameOver.ExplosionComplete();
        }
    }


}
