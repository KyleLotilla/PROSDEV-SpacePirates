using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriodCollision : MonoBehaviour
{
    public Transform asteroidTransform;
    public CircleCollider2D asteroidCollider;
    public Animator anim;
    public AudioSource audioSource;
    public AudioClip explosionSound;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerLaser")
        {
            audioSource.PlayOneShot(explosionSound, 0.3f);
            Destroy(asteroidCollider);
            asteroidTransform.localScale = new Vector3(0.3f, 0.3f, 1f);
            anim.SetBool("explode", true);
        }
    }
}
