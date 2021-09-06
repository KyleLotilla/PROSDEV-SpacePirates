using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.HealthSystem;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField]
        private Health health;
        [SerializeField]
        private IntVariable currentPlayerHealth;
        [SerializeField]
        private GameEvent playerDamaged;

        // Start is called before the first frame update
        void Start()
        {
            health.CurrentHealth = currentPlayerHealth.Value;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnHealthChanged(int oldHeath, int newHealth)
        {
            currentPlayerHealth.Value = newHealth;
            if (oldHeath > newHealth)
            {
                playerDamaged.Raise();
            }
        }


    }
}

