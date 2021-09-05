using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;
using DLSU.SpacePirates.HealthSystem;

namespace DLSU.SpacePirates.BossSystem.AlienSwarm
{
    [Serializable]
    public enum AlienSwarmState
    {
        PHASE_ONE_START,
        PHASE_ONE_PROJECTILE_SHOT,
        PHASE_ONE_MOVE,
        PHASE_TWO_ATTACK
    }

    public class AlienSwarmAI : MonoBehaviour
    {
        [SerializeField]
        private GameObject alienInsectPrefab;
        [SerializeField]
        private int alienInsectCount;
        [SerializeField]
        private float projectileShotChance;
        [SerializeField]
        private Vector2Variable topRightBound;
        [SerializeField]
        private Vector2Variable bottomLeftBound;
        [SerializeField]
        private Health health;
        [SerializeField]
        private float phaseOneStartTime;
        [SerializeField]
        private float phaseOneCooldownAfterShot;
        [SerializeField]
        private int numberOfNonMovingPairs;
        [SerializeField]
        private float phaseTwoAttackRate;
        [SerializeField]
        private AudioSource audioSource;
        private AlienSwarmState currentState = AlienSwarmState.PHASE_ONE_START;
        private List<AlienInsectAI> alienAIs;
        private List<AlienInsectShootProjectile> alienInsectShootProjectiles;
        private float ticks = 0.0f;
        private int phaseOneMovingCount = 0;
        // Start is called before the first frame update
        void Start()
        {
            SpawnAlienInsects();
            //TransitionIntoPhaseOneProjectileShot();
            //TransitionIntoPhaseTwoAttack();
        }

        // Update is called once per frame
        void Update()
        {
            if (currentState == AlienSwarmState.PHASE_ONE_START)
            {
                PhaseOneStart();
            }
            else if (currentState == AlienSwarmState.PHASE_ONE_PROJECTILE_SHOT)
            {
                PhaseOneProjectileShot();
            }
            else if (currentState == AlienSwarmState.PHASE_TWO_ATTACK)
            {
                PhaseTwoAttack();
            }
        }

        private void SpawnAlienInsects()
        {
            alienAIs = new List<AlienInsectAI>(alienInsectCount);
            alienInsectShootProjectiles = new List<AlienInsectShootProjectile>(alienInsectCount);
            float alienInsectHalfCount = alienInsectCount / 2;
            // Spawn a pair of left and right insects for every iteration
            for (int i = 0; i < alienInsectHalfCount; i++)
            {
                float spawnPositionY = Mathf.Lerp(bottomLeftBound.Value.y, topRightBound.Value.y, (float)i / (alienInsectHalfCount - 1));
                float spawnPositionX = bottomLeftBound.Value.x;
                Quaternion rotation = Quaternion.identity;
                SpawnAlienInsect(new Vector2(spawnPositionX, spawnPositionY), rotation);
                spawnPositionX = topRightBound.Value.x;
                rotation *= Quaternion.Euler(0.0f, 180.0f, 0.0f);
                SpawnAlienInsect(new Vector2(spawnPositionX, spawnPositionY), rotation);
            }
        }

        private void SpawnAlienInsect(Vector2 position, Quaternion rotation)
        {
            GameObject alienInsect = Instantiate(alienInsectPrefab, position, rotation);
            if (alienInsect != null)
            {
                AlienInsectAI alienInsectAI = alienInsect.GetComponent<AlienInsectAI>();
                if (alienInsectAI != null)
                {
                    alienAIs.Add(alienInsectAI);
                }
                AlienInsectShootProjectile alienInsectShootProjectile = alienInsect.GetComponent<AlienInsectShootProjectile>();
                if (alienInsectShootProjectile != null)
                {
                    alienInsectShootProjectiles.Add(alienInsectShootProjectile);
                }
                HealthHitBox healthHitBox = alienInsect.GetComponent<HealthHitBox>();
                if (healthHitBox != null)
                {
                    healthHitBox.Health = health;
                }
            }
        }

        private void PhaseOneStart()
        {
            ticks += Time.deltaTime;
            if (ticks >= phaseOneStartTime)
            {
                TransitionIntoPhaseOneProjectileShot();
            }
        }

        private void TransitionIntoPhaseOneProjectileShot()
        {
            ticks = 0.0f;
            AlienSwarmProjectileShot();
            currentState = AlienSwarmState.PHASE_ONE_PROJECTILE_SHOT;
        }

        private void PhaseOneProjectileShot()
        {
            ticks += Time.deltaTime;
            if (ticks >= phaseOneCooldownAfterShot)
            {
                TransitionIntoPhaseOneMove();
            }
        }

        private void TransitionIntoPhaseOneMove()
        {
            int nonMovingInsectIndex = UnityEngine.Random.Range(0, alienInsectCount - (2 * numberOfNonMovingPairs) + 1);
            // Start at the beginning of the pair
            if (nonMovingInsectIndex % 2 == 1)
            {
                nonMovingInsectIndex--;
            }
            for (int i = 0; i < alienInsectCount; i++)
            {
                if (i < nonMovingInsectIndex || i >= nonMovingInsectIndex + (2 * numberOfNonMovingPairs))
                {
                    alienAIs[i].MoveToOtherSide();
                    phaseOneMovingCount++;
                }
            }
            currentState = AlienSwarmState.PHASE_ONE_MOVE;
        }

        public void OnAlienMovedToOtherSide()
        {
            phaseOneMovingCount--;
            if (phaseOneMovingCount <= 0)
            {
                if (health.CurrentHealth < health.MaxHealth * 0.5)
                {
                    TransitionIntoPhaseTwoAttack();
                }
                else
                {
                    TransitionIntoPhaseOneProjectileShot();
                }
            }
        }

        public void TransitionIntoPhaseTwoAttack()
        {
            currentState = AlienSwarmState.PHASE_TWO_ATTACK;
            ticks = 0.0f;
            foreach (AlienInsectAI alienInsectAI in alienAIs)
            {
                alienInsectAI.TransitionIntoRandomMovement();
            }
        }

        public void PhaseTwoAttack()
        {
            ticks += Time.deltaTime;
            if (ticks >= phaseTwoAttackRate)
            {
                ticks = 0.0f;
                AlienSwarmProjectileShot();
            }
        }

        public void AlienSwarmProjectileShot()
        {
            audioSource.Play();
            foreach (AlienInsectShootProjectile alienInsectShootProjectile in alienInsectShootProjectiles)
            {
                float rand = UnityEngine.Random.Range(1.0f, 100.0f);
                if (rand <= projectileShotChance)
                {
                    alienInsectShootProjectile.ShootProjectile();
                }
            }
        }
    }
}

