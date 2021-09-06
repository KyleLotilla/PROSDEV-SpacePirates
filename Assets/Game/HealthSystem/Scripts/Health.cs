using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int maxHealth;
        public int MaxHealth
        {
            get
            {
                return maxHealth;
            }
            set
            {
                maxHealth = value;
            }
        }
        [SerializeField]
        private int currentHealth;
        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
            }
        }
        [SerializeField]
        private UnityEventTwoInt onHealthChanged;
        public UnityEventTwoInt OnHealthChanged
        {
            get
            {
                return onHealthChanged;
            }
        }
        [SerializeField]
        private UnityEvent onDeath;
        public UnityEvent OnDeath
        {
            get
            {
                return onDeath;
            }
        }
        [SerializeField]
        private bool isInvulnerable = false;
        public bool IsInvulnerable
        {
            get
            {
                return IsInvulnerable;
            }
            set
            {
                isInvulnerable = value;
            }
        }
        [SerializeField]
        private bool initializeMaxHealthToCurrentHealth = true;

        private void Start()
        {
            if (initializeMaxHealthToCurrentHealth)
            {
                currentHealth = maxHealth;
                onHealthChanged?.Invoke(currentHealth, currentHealth);
            }
        }

        private void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            if (!isInvulnerable)
            {
                int oldHealth = currentHealth;
                currentHealth = Mathf.Max(currentHealth - damage, 0);
                onHealthChanged?.Invoke(oldHealth, currentHealth);
                if (currentHealth <= 0)
                {
                    onDeath?.Invoke();
                }
            }
        }

        public void Heal(int heal)
        {
            int oldHealth = currentHealth;
            currentHealth += Mathf.Min(currentHealth + heal, maxHealth);
            onHealthChanged?.Invoke(oldHealth, currentHealth);
        }

    }
}

