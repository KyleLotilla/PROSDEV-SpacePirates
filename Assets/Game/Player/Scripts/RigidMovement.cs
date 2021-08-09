using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private float x;
    private float y;

    void Update()
    {
        rb.velocity = (new Vector2(Input.GetAxisRaw("Horizontal") * 7f, Input.GetAxisRaw("Vertical") * 7f));
    }
}
