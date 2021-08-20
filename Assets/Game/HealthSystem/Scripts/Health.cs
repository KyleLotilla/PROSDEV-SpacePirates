using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] 
    private int maxHealth;
    [SerializeField] 
    private int currentHealth;
    [SerializeField]
    private UnityEventTwoInt onHealthChanged;
    [SerializeField]
    private UnityEvent onDeath;

    private void Start()
    {
        currentHealth = maxHealth;
        onHealthChanged.Invoke(currentHealth, currentHealth);
    }

    private void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        int oldHealth = currentHealth;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        onHealthChanged.Invoke(oldHealth, currentHealth);
        if (currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }

    public void Heal(int heal)
    {
        int oldHealth = currentHealth;
        currentHealth += Mathf.Min(currentHealth + heal, maxHealth);
        onHealthChanged.Invoke(oldHealth, currentHealth);
    }

}
