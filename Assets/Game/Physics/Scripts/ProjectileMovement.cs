using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Physics
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D projectileRigidbody;
        [SerializeField]
        public Vector2 velocity;
        [SerializeField]
        private bool hasAcceleration;
        [Min(0.0f)]
        [SerializeField]
        private Vector2 minSpeed;
        [Min(0.0f)]
        [SerializeField]
        private Vector2 maxSpeed;
        [SerializeField]
        private Vector2 acceleration;
        [Min(0.0f)]
        [SerializeField]
        private float accelerationRate = 1.0f;

        private float ticks = 0.0f;
        void Start()
        {
            Vector2 currentVelocity = velocity;
            currentVelocity.x *= transform.right.x;
            currentVelocity.y *= transform.up.y;
            projectileRigidbody.velocity = currentVelocity;
        }

        private void FixedUpdate()
        {
            if (hasAcceleration)
            {
                ticks += Time.fixedDeltaTime;
                if (ticks >= accelerationRate)
                {
                    Accelerate();
                    ticks = 0.0f;
                }
            }
        }

        private void Accelerate()
        {
            Vector2 currentAcceleration = acceleration;
            currentAcceleration.x *= transform.right.x;
            currentAcceleration.y *= transform.up.y;
            Vector2 currentVelocity = projectileRigidbody.velocity;

            if (Mathf.Abs(currentVelocity.x + currentAcceleration.x) < minSpeed.x)
            {
                currentVelocity.x = minSpeed.x * transform.right.x;
            }
            else if (Mathf.Abs(currentVelocity.x + currentAcceleration.x) > maxSpeed.x)
            {
                currentVelocity.x = maxSpeed.x * transform.right.x;
            }
            else
            {
                currentVelocity.x = currentVelocity.x + currentAcceleration.x;
            }

            if (Mathf.Abs(currentVelocity.y + currentAcceleration.y) < minSpeed.y)
            {
                currentVelocity.y = minSpeed.y * transform.up.y;
            }
            else if (Mathf.Abs(currentVelocity.y + currentAcceleration.y) > maxSpeed.y)
            {
                currentVelocity.y = maxSpeed.y * transform.up.y;
            }
            else
            {
                currentVelocity.y = currentVelocity.y + currentAcceleration.y;
            }
            projectileRigidbody.velocity = currentVelocity;
        }
    }
}


