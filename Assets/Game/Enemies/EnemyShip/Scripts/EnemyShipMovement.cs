using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Enemies.SpacePirate
{
    public class EnemyShipMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D shipRigidBody;
        [SerializeField]
        private Vector2 minSpeed;
        [SerializeField]
        private Vector2 maxSpeed;
        [SerializeField]
        private Vector2Variable topRightBound;
        [SerializeField]
        private Vector2Variable bottomLeftBound;
        [SerializeField]
        private bool shouldStandStill = true;
        [SerializeField]
        [Min(0.0f)]
        private float standStillDuration;
        private float MOVE_RATE = 0.5f;
        private float ticks = 0.0f;
        private bool isMoving;
        private bool isInsideBounds = false;
        void Start()
        {
            MoveInsideBounds();
        }

        public void Update()
        {
            if (!isInsideBounds)
            {
                CheckIfInsideBounds();
            }
            else
            {
                if (isMoving)
                {
                    ticks += Time.fixedDeltaTime;
                    if (ticks >= MOVE_RATE)
                    {
                        if (transform.position.x >= topRightBound.Value.x || transform.position.y >= topRightBound.Value.y || transform.position.x <= bottomLeftBound.Value.x || transform.position.y <= bottomLeftBound.Value.y)
                        {
                            ticks = 0.0f;
                            if (shouldStandStill)
                            {
                                StandStll();
                            }
                            else
                            {
                                MoveShip();
                            }
                        }
                    }
                }
                else
                {
                    ticks += Time.deltaTime;
                    if (ticks >= standStillDuration)
                    {
                        MoveShip();
                    }
                }
            }
        }

        private void MoveInsideBounds()
        {
            Vector2 currentVeloctiy = new Vector2(0, 0);
            if (transform.position.x > topRightBound.Value.x)
            {
                currentVeloctiy.x = -maxSpeed.x;
            }
            else if (transform.position.x < bottomLeftBound.Value.x)
            {
                currentVeloctiy.x = maxSpeed.x;
            }

            if (transform.position.y > topRightBound.Value.y)
            {
                currentVeloctiy.y = -maxSpeed.y;
            }
            else if (transform.position.y < bottomLeftBound.Value.y)
            {
                currentVeloctiy.y = maxSpeed.y;
            }

            if (currentVeloctiy.sqrMagnitude == 0)
            {
                isInsideBounds = true;
                MoveShip();
            }
            else
            {
                shipRigidBody.velocity = currentVeloctiy;
            }
        }

        private void CheckIfInsideBounds()
        {
            if (transform.position.x >= bottomLeftBound.Value.x && transform.position.x <= topRightBound.Value.x)
            {
                Vector2 currentVelocity = shipRigidBody.velocity;
                currentVelocity.x = 0.0f;
                shipRigidBody.velocity = currentVelocity;
            }
            if (transform.position.y >= bottomLeftBound.Value.y && transform.position.y <= topRightBound.Value.y)
            {
                Vector2 currentVelocity = shipRigidBody.velocity;
                currentVelocity.y = 0.0f;
                shipRigidBody.velocity = currentVelocity;
            }
            if (shipRigidBody.velocity.sqrMagnitude == 0)
            {
                isInsideBounds = true;
                MoveShip();
            }
        }

        private void MoveShip()
        {
            float[] directions = new float[2] { 1.0f, -1.0f };
            Vector2 newVelocity = new Vector2(Random.Range(minSpeed.x, maxSpeed.x), Random.Range(minSpeed.y, maxSpeed.y));
            if (transform.position.x >= topRightBound.Value.x)
            {
                newVelocity.x *= -1.0f;
            }
            else if (transform.position.x > bottomLeftBound.Value.x)
            {
                newVelocity.x *= directions[Random.Range(0, 2)];
            }

            if (transform.position.y >= topRightBound.Value.y)
            {
                newVelocity.y *= -1.0f;
            }
            else if (transform.position.y > bottomLeftBound.Value.y)
            {
                newVelocity.y *= directions[Random.Range(0, 2)];
            }
            shipRigidBody.velocity = newVelocity;
            isMoving = true;
        }

        private void StandStll()
        {
            ticks = 0.0f;
            isMoving = false;
            shipRigidBody.velocity = new Vector2(0.0f, 0.0f);
        }
    }


}

