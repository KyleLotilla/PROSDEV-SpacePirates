using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DLSU.SpacePirates.BossSystem.SpaceBeard
{
    public class SpaceBeardShooting : MonoBehaviour
    {
        [SerializeField]
        private GameObject skullProjectile;
        [SerializeField]
        private Transform spawnPosition;
        [SerializeField]
        private float fireRate;

        private float ticks = 0.0f;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ticks += Time.deltaTime;
            if (ticks >= fireRate)
            {
                SpawnProjectile();
                ticks = 0.0f;
            }
        }

        public void SpawnProjectile()
        {
            Instantiate(skullProjectile, transform.position, Quaternion.identity);
        }
    }

}
