using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int maxpHP = 1000;
    int currHP;
    public SpriteRenderer sprite;
    public Transform bossShoot;
    public GameObject bossLaser;
    public Slider slider;
    // Start is called before the first frame update
    
    void Start()
    {
        currHP = maxpHP;
        slider.maxValue = maxpHP;
        slider.value = maxpHP;
    }

    // Update is called once per frame
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(100);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }
   
    public void SetHealth(int hp)
    {
        slider.value = hp;
    }
    
    void Shoot()
    {
        Instantiate(bossLaser, bossShoot.position, bossShoot.rotation);
    }

    public void TakeDamage(int dmg)
    {
        currHP -= dmg;
        slider.value = currHP;

        if (currHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        sprite.enabled = false;
        this.enabled = false;
    }
}
