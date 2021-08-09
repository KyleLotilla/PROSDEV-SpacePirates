using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaserMovement : MonoBehaviour
{
    public Rigidbody2D laser;
    public float speed;

    void Start()
    {
        laser.velocity = new Vector2(-5f * speed, 0f);
    }
}
