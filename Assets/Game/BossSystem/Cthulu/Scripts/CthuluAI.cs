using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem.AlienHead
{
    [Serializable]
    public enum CthuluState
    {
        REGULAR_MOVEMENT,
        FORWARD_ATTACK,
        FORWARD_ATTACK_END,
        CHARGING_BEAM,
        BEAM_FIRING
    }

    public class CthuluAI : MonoBehaviour
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
        private CthuluState currentState;
        [SerializeField]
        private float attackCooldown;
        [SerializeField]
        private float forwardAttackRate;
        [SerializeField]
        private float fireBeamRate;
        [SerializeField]
        private GameObject beamPrefab;
        [SerializeField]
        private Transform beamSpawnPosition;
        [SerializeField]
        private float beamChargeUpTime;
        [SerializeField]
        private float beamFireTime;
        private GameObject currentBeamInstance;
        private float ticks = 0.0f;
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private AudioClip forwardAttackSFX;
        [SerializeField]
        private AudioClip chargeUpSFX;
        [SerializeField]
        private AudioClip fireBeamSFX;


        // Start is called before the first frame update
        void Start()
        {
            TransitionIntoRegularMovement();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == CthuluState.REGULAR_MOVEMENT)
            {
                ticks += Time.deltaTime;
                if (ticks >= attackCooldown)
                {
                    float rand = UnityEngine.Random.Range(1.0f, 100.0f);
                    if (rand <= fireBeamRate)
                    {
                        TransitionIntoChargingBeam();
                    }
                    else
                    {
                        rand = UnityEngine.Random.Range(1.0f, 100.0f);
                        if (rand <= forwardAttackRate)
                        {
                            TransitionIntoForwardAttack();
                        }
                        else
                        {
                            RegularMovement();
                        }
                    }
                }
                else
                {
                    RegularMovement();
                }

            }
            else if (currentState == CthuluState.FORWARD_ATTACK)
            {
                ForwardAttack();
            }
            else if (currentState == CthuluState.FORWARD_ATTACK_END)
            {
                ForwardAttackEnd();
            }
            else if (currentState == CthuluState.CHARGING_BEAM)
            {
                ChargingBeam();
            }
            else if(currentState == CthuluState.BEAM_FIRING)
            {
                BeamFiring();
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
            currentState = CthuluState.REGULAR_MOVEMENT;
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
            audioSource.Stop();
            audioSource.clip = forwardAttackSFX;
            audioSource.loop = false;
            audioSource.Play();
            alienRigidBody.velocity = new Vector2(-speed * 2, 0.0f);
            currentState = CthuluState.FORWARD_ATTACK;
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
            currentState = CthuluState.FORWARD_ATTACK_END;
        }

        public void ForwardAttackEnd()
        {
            if (transform.position.x >= rightBound)
            {
                TransitionIntoRegularMovement();
            }
        }

        public void TransitionIntoChargingBeam()
        {
            ticks = 0.0f;
            alienRigidBody.velocity = new Vector2(0.0f, 0.0f);
            animator.SetBool("openMouth", true);
            audioSource.Stop();
            audioSource.clip = chargeUpSFX;
            audioSource.loop = true;
            audioSource.Play();
            currentState = CthuluState.CHARGING_BEAM;
        }

        public void ChargingBeam()
        {
            ticks += Time.deltaTime;
            if (ticks >= beamChargeUpTime)
            {
                ticks = 0.0f;
                TransitionIntoBeamFiring();
            }
        }

        public void TransitionIntoBeamFiring()
        {
            currentBeamInstance = Instantiate(beamPrefab, beamSpawnPosition.position, Quaternion.identity);
            if (currentBeamInstance != null)
            {
                ticks = 0.0f;
                audioSource.Stop();
                audioSource.clip = fireBeamSFX;
                audioSource.loop = false;
                audioSource.Play();
                currentState = CthuluState.BEAM_FIRING;
            }
            else
            {
                TransitionIntoRegularMovement();
            }
        }

        public void BeamFiring()
        {
            ticks += Time.deltaTime;
            if (ticks >= beamFireTime)
            {
                Destroy(currentBeamInstance);
                currentBeamInstance = null;
                animator.SetBool("openMouth", false);
                TransitionIntoRegularMovement();
            }
        }

        public void OnDeath()
        {
            if (currentBeamInstance != null)
            {
                Destroy(currentBeamInstance);
            }
        }
    }
}

