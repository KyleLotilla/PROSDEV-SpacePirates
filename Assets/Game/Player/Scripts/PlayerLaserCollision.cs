using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserCollision : MonoBehaviour
{
    public Score score;
    public GameObject laser;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            score.addScore(10);
            Destroy(laser);
        }
    }
}
