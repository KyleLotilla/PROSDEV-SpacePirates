using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;
using System.Linq;

namespace DLSU.SpacePirates.EnemySpawn
{
    public class EncounterSpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyDatabase enemyDatabase;
        [SerializeField]
        private FloatVariable strength;
        [SerializeField]
        private GameEvent encounterStarted;
        [SerializeField]
        private GameEvent encounterFinished;

        private Encounter currentEncounter;
        private float timeInCurrentEncounter = 0.0f;
        private List<EnemySpawnInstance> currentEnemySpawns;
        private int currentEnemySpawnIndex = 0;
        private int activeEnemiesCount = 0;
        private bool allEnemiesSpawned = true;

        void Start()
        {

        }

        void Update()
        {
            if (!allEnemiesSpawned)
            {
                timeInCurrentEncounter += Time.deltaTime;
                if (timeInCurrentEncounter >= currentEnemySpawns[currentEnemySpawnIndex].spawnDelayTime)
                {
                    SpawnNextEnemies();
                }
            }
        }

        public void StartEncounter(Encounter encounter)
        {
            currentEncounter = encounter;
            currentEnemySpawns = currentEncounter.enemySpawns.OrderBy(x => x.spawnDelayTime).ToList();
            currentEnemySpawnIndex = 0;
            timeInCurrentEncounter = 0.0f;
            strength.Value = currentEncounter.initialStrength;
            allEnemiesSpawned = false;
            encounterStarted.Raise();
        }

        private void SpawnNextEnemies()
        {
            bool shouldSpawn = true;
            while (shouldSpawn)
            {
                if (timeInCurrentEncounter >= currentEnemySpawns[currentEnemySpawnIndex].spawnDelayTime)
                {
                    SpawnEnemy();
                    currentEnemySpawnIndex++;
                    strength.Value = Mathf.Lerp(currentEncounter.initialStrength, currentEncounter.maxStrength, (float)(currentEnemySpawnIndex) / (currentEnemySpawns.Count - 1));
                    if (currentEnemySpawnIndex >= currentEnemySpawns.Count)
                    {
                        allEnemiesSpawned = true;
                        shouldSpawn = false;
                    }
                }
                else
                {
                    shouldSpawn = false;
                }
            }
        }

        private void SpawnEnemy()
        {
            Debug.Assert(timeInCurrentEncounter >= currentEnemySpawns[currentEnemySpawnIndex].spawnDelayTime, "Spawning Enemy should not be spawned at this timepoint");
            EnemySpawnInstance enemySpawnInstance = currentEnemySpawns[currentEnemySpawnIndex];
            GameObject enemyPrefab = enemyDatabase.GetEnemy(enemySpawnInstance.enemyID);
            activeEnemiesCount++;
            GameObject enemy = Instantiate(enemyPrefab, (Vector3)(enemySpawnInstance.spawnPosition), enemySpawnInstance.spawnRotation);
            Debug.Assert(enemy != null, "Enemy not spawned");
        }

        public void OnActiveEnemyDeath()
        {
            activeEnemiesCount--;
            if (activeEnemiesCount <= 0 && allEnemiesSpawned)
            {
                encounterFinished.Raise();
            }
        }
    }
}

