using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObjectMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(-9f, 0f);   
    }
}
