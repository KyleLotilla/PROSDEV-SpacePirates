using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    int direction;
    public float speed;

    void Start()
    {
        direction = Random.Range(-1, 2);
        rb.velocity = new Vector2(-3f * speed, 0.2f * (float)(direction));
    }
}
