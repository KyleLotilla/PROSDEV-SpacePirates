using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissileCollision : MonoBehaviour
{
    public Score score;
    public GameObject missile;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            score.addScore(10);
            Destroy(missile);
        }
    }
}
