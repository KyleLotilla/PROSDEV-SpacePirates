using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.HealthSystem;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.BossSystem
{
    public class BossHealthBar : MonoBehaviour
    {
        [SerializeField]
        private HealthBar healthBar;
        [SerializeField]
        private GameObjectVariable boss;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnBossSpawned()
        {
            if (boss.Value != null)
            {
                Health health = boss.Value.GetComponent<Health>();
                if (health != null)
                {
                    healthBar.Health = health;
                }
            }
        }
    }
}

