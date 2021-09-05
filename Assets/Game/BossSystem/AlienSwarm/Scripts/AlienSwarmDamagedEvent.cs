using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.BossSystem.AlienSwarm
{
    public class AlienSwarmDamagedEvent : MonoBehaviour
    {
        [SerializeField]
        private GameEvent alienSwarmDamaged;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnHealthChanged(int oldHealth, int newHealth)
        {
            if (oldHealth > newHealth)
            {
                alienSwarmDamaged.Raise();
            }
        }
    }
}

