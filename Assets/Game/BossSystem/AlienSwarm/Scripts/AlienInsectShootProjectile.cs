using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.BossSystem.AlienSwarm
{
    public class AlienInsectShootProjectile : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectilePrefab;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private Vector2 minProjectileSpeed;
        [SerializeField]
        private Vector2 maxProjectileSpeed;
        [SerializeField]
        private Vector2Variable topRightBound;
        [SerializeField]
        private Vector2Variable bottomLeftBound;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }

        public void ShootProjectile()
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Rigidbody2D projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
            if (projectileRigidBody != null)
            {
                animator.SetTrigger("shoot");
                float currentVelocityX = Random.Range(minProjectileSpeed.x, maxProjectileSpeed.x) * transform.right.x;
                float currentVelocityY = Random.Range(minProjectileSpeed.y, maxProjectileSpeed.y);
                float distanceFromTopBound = Mathf.Abs(transform.position.y - topRightBound.Value.y);
                float distanceFromBottomBound = Mathf.Abs(transform.position.y - bottomLeftBound.Value.y);
                if (distanceFromTopBound < distanceFromBottomBound)
                {
                    currentVelocityY *= -1.0f;
                }
                projectileRigidBody.velocity = new Vector2(currentVelocityX, currentVelocityY);
            }
        }
    }

}
