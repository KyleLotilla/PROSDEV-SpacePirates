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
        [SerializeField]
        private Vector2 minVelocity;
        [SerializeField]
        private Vector2 maxVelocity;
        [SerializeField]
        private Vector2 acceleration;
        [Min(0.0f)]
        [SerializeField]
        private float accelerationRate = 1.0f;

        private float ticks = 0.0f;
        void Start()
        {
            projectileRigidbody.velocity = velocity;
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
            Vector2 currentVelocity = projectileRigidbody.velocity;
            currentVelocity.x = Mathf.Max(currentVelocity.x + acceleration.x, minVelocity.x);
            currentVelocity.x = Mathf.Min(currentVelocity.x, maxVelocity.x);
            currentVelocity.y = Mathf.Max(currentVelocity.y + acceleration.y, minVelocity.y);
            currentVelocity.y = Mathf.Min(currentVelocity.y, maxVelocity.y);
            projectileRigidbody.velocity = currentVelocity;
        }
    }
}


