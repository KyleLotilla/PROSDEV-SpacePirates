using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed;

    void Start()
    {
        rb2d.velocity = new Vector3(-3.5f * speed, 0, 0);
    }
}
