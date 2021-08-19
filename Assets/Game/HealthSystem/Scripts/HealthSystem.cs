using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private HealthBar healthBar;
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {

       
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(10);
        }

        else if (Input.GetKeyDown(KeyCode.I))
        {
            Heal(5);
        } 
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        healthBar.SetHealth(currentHealth);
        //if collided with hostile objects reduce health
        //if health 0 uhhh D I E. 
    }

    private void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
        //if collided with heal power up or regeneration then increase health;
        
    }

}
