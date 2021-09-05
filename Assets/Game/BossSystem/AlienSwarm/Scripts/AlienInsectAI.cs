using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.BossSystem.AlienSwarm
{
    public enum AlienInsectState
    {
        IDLE,
        MOVING_TO_OTHER_SIDE,
        RANDOM_MOVEMENT,
        RANDOM_STAND_STILL
    }

    public class AlienInsectAI : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D alienRigidBody;
        [SerializeField]
        private float moveToOtherSideSpeed;
        [SerializeField]
        private Vector2Variable topRightBound;
        [SerializeField]
        private Vector2Variable bottomLeftBound;
        [SerializeField]
        private GameEvent alienMovedToOtherSide;
        [SerializeField]
        private float randomMovementBoundOffsetX;
        [SerializeField]
        private Vector2 minRandomMovementSpeed;
        [SerializeField]
        private Vector2 maxRandomMovementSpeed;
        [SerializeField]
        private float randomMovementChangeRate;
        [SerializeField]
        private float standStillDuration;
        private float ticks = 0.0f;
        private AlienInsectState currentState = AlienInsectState.IDLE;
        // Start is called before the first frame update
        void Start()
        {
            //TransitionIntoRandomMovement();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == AlienInsectState.MOVING_TO_OTHER_SIDE)
            {
                MovingToOtherSide();
            }
            else if (currentState == AlienInsectState.RANDOM_MOVEMENT)
            {
                RandomMovement();
            }
            else if (currentState == AlienInsectState.RANDOM_STAND_STILL)
            {
                RandomStandStill();
            }
        }

        public void MoveToOtherSide()
        {
            alienRigidBody.velocity = new Vector2(moveToOtherSideSpeed * transform.right.x, 0.0f);
            currentState = AlienInsectState.MOVING_TO_OTHER_SIDE;
        }

        private void MovingToOtherSide()
        {
            float rightBound = topRightBound.Value.x;
            float leftBound = bottomLeftBound.Value.x;
            float direction = transform.right.x;
            if ((direction > 0.0f && transform.position.x >= rightBound) || (direction < 0.0f && transform.position.x <= leftBound))
            {
                currentState = AlienInsectState.IDLE;
                alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
                transform.rotation *= Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));
                alienMovedToOtherSide.Raise();
            }
        }

        public void TransitionIntoRandomMovement()
        {
            currentState = AlienInsectState.RANDOM_MOVEMENT;
            ticks = 0.0f;
            float localRightBoundX = GetRandomMovementLocalRightBoundX();
            float localLeftBoundX = GetRandomMovementLocalLeftBoundX();
            float[] directions = new float[2] { 1.0f, -1.0f };
            float randomSpeedX = Random.Range(minRandomMovementSpeed.x, maxRandomMovementSpeed.x);
            float randomSpeedY = Random.Range(minRandomMovementSpeed.y, maxRandomMovementSpeed.y);
            Vector2 currentVelocity = new Vector2(randomSpeedX, randomSpeedY);

            if (transform.position.x >= localRightBoundX)
            {
                currentVelocity.x *= -1.0f;
            }
            else if (transform.position.x > localLeftBoundX)
            {
                currentVelocity.x *= directions[Random.Range(0, 2)];
            }

            if (transform.position.y >= topRightBound.Value.y)
            {
                currentVelocity.y *= -1.0f;
            }
            else if (transform.position.y > bottomLeftBound.Value.y)
            {
                currentVelocity.y *= directions[Random.Range(0, 2)];
            }

            alienRigidBody.velocity = currentVelocity;
        }

        private void RandomMovement()
        {
            ticks += Time.fixedDeltaTime;
            if (ticks >= randomMovementChangeRate)
            {
                float localRightBoundX = GetRandomMovementLocalRightBoundX();
                float localLeftBoundX = GetRandomMovementLocalLeftBoundX();
                if (transform.position.x >= localRightBoundX || transform.position.y >= topRightBound.Value.y || transform.position.x <= localLeftBoundX || transform.position.y <= bottomLeftBound.Value.y)
                {
                    TransitionIntoRandomStandStill();
                }
            }
        }

        private float GetRandomMovementLocalRightBoundX()
        {
            float direction = transform.right.x;
            float localRightBoundX = topRightBound.Value.x;
            if (direction > 0.0f)
            {
                localRightBoundX = bottomLeftBound.Value.x + randomMovementBoundOffsetX;
            }
            return localRightBoundX;
        }

        private float GetRandomMovementLocalLeftBoundX()
        {
            float direction = transform.right.x;
            float localLeftBoundX = bottomLeftBound.Value.x;
            if (direction < 0.0f)
            {
                localLeftBoundX = topRightBound.Value.x - randomMovementBoundOffsetX;
            }
            return localLeftBoundX;
        }

        public void TransitionIntoRandomStandStill()
        {
            currentState = AlienInsectState.RANDOM_STAND_STILL;
            ticks = 0.0f;
            alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
        }

        private void RandomStandStill()
        {
            ticks += Time.deltaTime;
            if (ticks >= standStillDuration)
            {
                TransitionIntoRandomMovement();
            }
        }
    }
}

