using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMineCollision : MonoBehaviour
{
    public Transform enemyMineTransform;
    public CircleCollider2D enemyMineCollider;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip explosionSound;
    public int Health = 2;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerLaser")
        {
            Health--;          
        }

        if(Health == 0)
        {
            audioSource.PlayOneShot(explosionSound, 0.3f);
            Destroy(enemyMineCollider);
            enemyMineTransform.localScale = new Vector3(0.3f, 0.3f, 1f);
            anim.SetBool("explode", true);
        }
    }
}
