using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Vector2 speed;

    void Update()
    {
        rb.velocity = (new Vector2(Input.GetAxisRaw("Horizontal") * speed.x, Input.GetAxisRaw("Vertical") * speed.y));
    }
}
