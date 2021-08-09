using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : MonoBehaviour
{
    
    public GameObject booster;
    public RigidMovement movement;
    public PlayerShoot shoot;
    public BoxCollider2D shipCollider;
    public Rigidbody2D playerBody;


    public AudioSource sound;
    public AudioClip explosionSound;
    public Animator anim;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "EnemyLaser":
            case "Obstacle":
            case "Blackhole":
                sound.PlayOneShot(explosionSound, 0.8f);
                playerBody.velocity = Vector2.zero;
                DisableShip();
                anim.SetBool("explode", true);
                break;
        }
            
    }

    public void DisableShip()
    {
        movement.enabled = false;
        shoot.enabled = false;
        shipCollider.enabled = false;
        Destroy(booster);
    }
}
