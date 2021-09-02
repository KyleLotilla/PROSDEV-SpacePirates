using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.HealthSystem
{
    public class DamageSound : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip damageSound;

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
            if (oldHealth > newHealth && newHealth > 0)
            {
                audioSource.PlayOneShot(damageSound);
            }
        }
    }

}
