using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRigidBody;
    [SerializeField]
    private Vector2 speed;

    void Update()
    {
        playerRigidBody.velocity = (new Vector2(Input.GetAxisRaw("Horizontal") * speed.x, Input.GetAxisRaw("Vertical") * speed.y));
    }
}
