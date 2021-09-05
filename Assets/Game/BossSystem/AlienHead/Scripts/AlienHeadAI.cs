﻿using System;
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
        CHARGING_LASER,
        LASER,
        LASER_FIRING,
        LASER_END
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
        private float fireLaserRate;
        [SerializeField]
        private GameObject laserProjectile;
        [SerializeField]
        private Transform spawnLaserPosition;

        [SerializeField]
        private float ticks = 0.0f;
        [SerializeField]
        private float ChargeUpTime;
        private float PreviousChargeUpTime;

        [SerializeField]
        private float LaserFireTime;
        private float PreviousLaserFireTime;

        private GameObject beam;

        [SerializeField]
        private Animator AlienHeadAnimations;

        [SerializeField]
        private AudioSource ForwardAttackSFX;

        [SerializeField]
        private AudioSource ChargeUpSFX;

        [SerializeField]
        private AudioSource FireLaserSFX;


        // Start is called before the first frame update
        void Start()
        {
            TransitionIntoRegularMovement();
            PreviousChargeUpTime = ChargeUpTime;
            PreviousLaserFireTime = LaserFireTime;
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
                    else if(rand > forwardAttackRate && rand <= fireLaserRate)
                    {
                        TransitionIntoChargeLaser();
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
            else if (currentState == AlienHeadState.CHARGING_LASER)
            {
                ChargeLaser();
            }
            else if(currentState == AlienHeadState.LASER)
            {
                LaserAttack();
            }
            else if(currentState == AlienHeadState.LASER_FIRING)
            {
                TransitionIntoLaserAttackEnd();
            }
            else if(currentState == AlienHeadState.LASER_END)
            {
                ChargeUpTime = PreviousChargeUpTime;
                LaserFireTime = PreviousLaserFireTime;
                TransitionIntoRegularMovement();
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
            AlienHeadAnimations.SetBool("AlienHeadIdleAnimation", true);
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

        public void TransitionIntoChargeLaser()
        {
            alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
            currentState = AlienHeadState.CHARGING_LASER;
        }

        public void ChargeLaser()
        {
            AlienHeadAnimations.SetBool("AlienHeadIdleAnimation", false);
            AlienHeadAnimations.SetBool("AlienHeadChargeUp", true);
            ChargeUpSFX.Play();
            if (ChargeUpTime > 0)
            {
                ChargeUpTime -= Time.deltaTime;
            }
            else
            {
                TransitionIntoFireLaser();
                
            }
        }

        public void TransitionIntoFireLaser()
        {
            //RegularMovement();
            ChargeUpSFX.clip = FireLaserSFX.clip;
            currentState = AlienHeadState.LASER;
        }

        public void TransitionIntoLaserAttackEnd()
        {
            AlienHeadAnimations.SetBool("AlienHeadAfterFire", true);
            if (LaserFireTime > 0)
            {
                LaserFireTime -= Time.deltaTime;
                alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
            }
            else
            {
                Destroy(beam);
                currentState = AlienHeadState.LASER_END;
            }
        }

        public void ForwardAttack()
        {
            ForwardAttackSFX.Play();
            if (transform.position.x <= leftBound)
            {
                TransitionIntoForwardAttackEnd();
            }
        }

        public void LaserAttack()
        {
            ChargeUpSFX.Play();
            AlienHeadAnimations.SetBool("AlienHeadChargeUp", false);
            AlienHeadAnimations.SetBool("AlienHeadIdleAnimation", false);
            alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
            beam = Instantiate(laserProjectile, spawnLaserPosition.position, Quaternion.identity);
            currentState = AlienHeadState.LASER_FIRING;
            
        }

        public void TransitionIntoForwardAttackEnd()
        {
            alienRigidBody.velocity = new Vector2(speed, 0.0f);
            ForwardAttackSFX.Stop();
            currentState = AlienHeadState.FORWARD_ATTACK_END;
        }

        public void ForwardAttackEnd()
        {
            //ForwardAttackSFX.Stop();
            if (transform.position.x >= rightBound)
            {
                TransitionIntoRegularMovement();
            }
        }
    }
}

