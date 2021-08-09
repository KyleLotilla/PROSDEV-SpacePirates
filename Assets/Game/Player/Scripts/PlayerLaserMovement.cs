using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserMovement : MonoBehaviour
{
    public Rigidbody2D laser;

    void Start()
    {
        laser.velocity = new Vector2(18f, 0f);
    }

}

