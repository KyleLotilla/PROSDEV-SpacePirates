using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePrefab : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    //public GameObject impactEffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
