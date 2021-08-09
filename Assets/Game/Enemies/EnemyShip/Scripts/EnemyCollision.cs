using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public EnemyShoot shoot;
    public BoxCollider2D enemyCollider;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip explosionSound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "PlayerLaser":
                audioSource.PlayOneShot(explosionSound, 0.3f);
                startExplosion();
                break;
            case "Player":
                startExplosion();
                break;
        }
    }

    public void startExplosion()
    {
        Destroy(shoot);
        Destroy(enemyCollider);
        anim.SetBool("explode", true);
    }
}
