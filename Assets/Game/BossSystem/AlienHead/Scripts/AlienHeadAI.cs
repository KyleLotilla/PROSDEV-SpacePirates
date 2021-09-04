using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem.AlienHead
{
    [Serializable]
    public enum AlienHeadState
    {
        REGULAR_MOVEMENT,
        FORWARD_ATTACK,
        FORWARD_ATTACK_END,
        LASER
    }

    public class AlienHeadAI : MonoBehaviour
    {
        [SerializeField]
        private float topBound;
        [SerializeField]
        private float buttomBound;
        [SerializeField]
        private float rightBound;
        [SerializeField]
        private float leftBound;
        [SerializeField]
        private Rigidbody2D alienRigidBody;
        [SerializeField]
        private float speed;
        [SerializeField]
        private AlienHeadState currentState;
        [SerializeField]
        private float cooldown;
        [SerializeField]
        private float forwardAttackRate;
        [SerializeField]
        private float ticks = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            TransitionIntoRegularMovement();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == AlienHeadState.REGULAR_MOVEMENT)
            {
                ticks += Time.deltaTime;
                if (ticks >= cooldown)
                {
                    float rand = UnityEngine.Random.Range(1.0f, 100.0f);
                    if (rand <= forwardAttackRate)
                    {
                        TransitionIntoForwardAttack();
                    }
                    else
                    {
                        RegularMovement();
                    }
                }
                else
                {
                    RegularMovement();
                }

            }
            else if (currentState == AlienHeadState.FORWARD_ATTACK)
            {
                ForwardAttack();
            }
            else if (currentState == AlienHeadState.FORWARD_ATTACK_END)
            {
                ForwardAttackEnd();
            }
        }

        public void TransitionIntoRegularMovement()
        {
            alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
            RegularMovement();
            if (alienRigidBody.velocity.sqrMagnitude == 0)
            {
                float rand = UnityEngine.Random.Range(1.0f, 100.0f);
                if (rand <= 50)
                {
                    alienRigidBody.velocity = new Vector2(0.0f, speed);
                }
                else
                {
                    alienRigidBody.velocity = new Vector2(0.0f, -speed);
                }
            }
            ticks = 0.0f;
            currentState = AlienHeadState.REGULAR_MOVEMENT;
        }

        public void RegularMovement()
        {
            if (transform.position.y >= topBound)
            {
                alienRigidBody.velocity = new Vector2(0.0f, -speed);
            }
            else if (transform.position.y <= buttomBound)
            {
                alienRigidBody.velocity = new Vector2(0.0f, speed);
            }
        }


        public void TransitionIntoForwardAttack()
        {
            alienRigidBody.velocity = new Vector2(-speed * 2, 0.0f);
            currentState = AlienHeadState.FORWARD_ATTACK;
        }

        public void ForwardAttack()
        {
            if (transform.position.x <= leftBound)
            {
                TransitionIntoForwardAttackEnd();
            }
        }

        public void TransitionIntoForwardAttackEnd()
        {
            alienRigidBody.velocity = new Vector2(speed, 0.0f);
            currentState = AlienHeadState.FORWARD_ATTACK_END;
        }

        public void ForwardAttackEnd()
        {
            if (transform.position.x >= rightBound)
            {
                TransitionIntoRegularMovement();
            }
        }
    }
}

