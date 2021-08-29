using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.WeaponSystem;

namespace DLSU.SpacePirates.Enemies.SpacePirate
{
    public class EnemyShootWeapon : MonoBehaviour
    {
        [SerializeField]
        private Weapon weapon;
        [SerializeField]
        private Transform barrelTransform;
        [SerializeField]
        private Animator barrelAnimator;
        private float ticks = 0.0f;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            ticks += Time.deltaTime;
            if (ticks >= weapon.FireRate)
            {
                ShootWeapon();
                ticks = 0.0f;
            }
        }

        private void ShootWeapon()
        {
            GameObject projectile = Instantiate(weapon.ProjectilePrefab, barrelTransform.position, barrelTransform.rotation);
            Debug.Assert(projectile != null, "Projectile not spawned");
            barrelAnimator.SetTrigger("shoot");
        }
    }
}

