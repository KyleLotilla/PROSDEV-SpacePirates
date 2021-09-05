using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.HealthSystem
{
    public class HealthHitBox : MonoBehaviour
    {
        [SerializeField]
        private Health health;
        [SerializeField]
        private bool canHit = true;

        public bool CanHit
        {
            get
            {
                return canHit;
            }
            set
            {
                canHit = value;
            }
        }

        public Health Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            if (canHit)
            {
                health.TakeDamage(damage);
            }
        }
    }
}

