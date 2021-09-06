using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.HealthSystem
{
    public class InvulnerableAfterDamaged : MonoBehaviour
    {
        [SerializeField]
        private float invulnerableTime;
        [SerializeField]
        private Health health;
        private bool isDamaged = false;
        private float ticks = 0.0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (isDamaged)
            {
                ticks += Time.deltaTime;
                if (ticks >= invulnerableTime)
                {
                    ticks += 0.0f;
                    isDamaged = false;
                    health.IsInvulnerable = false;
                }
            }
        }

        public void OnHealthChanged(int oldHealth, int newHealth)
        {
            if (oldHealth > newHealth && newHealth > 0)
            {
                health.IsInvulnerable = true;
                isDamaged = true;
            }
        }
    }
}

