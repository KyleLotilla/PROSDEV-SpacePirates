using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.HealthSystem
{
    public class HealthHitBox : MonoBehaviour
    {
        [SerializeField]
        private Health health;
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
            health.TakeDamage(damage);
        }
    }
}

