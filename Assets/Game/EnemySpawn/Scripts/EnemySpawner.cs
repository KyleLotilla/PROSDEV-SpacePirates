using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Level;

namespace DLSU.SpacePirates.EnemySpawn
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField]
        private EnemyDatabase enemyDatabase;
        [SerializeField]
        private LevelVariable currentLevel;
        [SerializeField]
        private IntVariable currentEncounterCount;
        [SerializeField]
        private IntVariable maxEncounterCount;
        [SerializeField]
        private FloatVariable strength;

        [SerializeField]
        private GameEvent encounterFinished;
        [SerializeField]
        private GameEvent allEncountersFinished;

        private List<Encounter> levelEncounters;
        private Encounter currentEncounter;
        private float timeInCurrentEncounter = 0.0f;
        private List<EnemySpawnInstance> currentEnemySpawns;
        private int currentEnemySpawnIndex = 0;
        private int activeEnemiesCount = 0;
        private bool isEncountersFinished = false;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Assert(currentLevel.Value != null, "Level not initialized yet");
            levelEncounters = currentLevel.Value.Encounters;
            StartEncounter();
        }

        private void StartEncounter()
        {
            Debug.Assert(currentEncounterCount.Value >= 0 && currentEncounterCount.Value < maxEncounterCount.Value, "Current Encounter Count out of bounds");
            currentEncounter = levelEncounters[currentEncounterCount.Value];
            currentEnemySpawns = currentEncounter.EnemySpawns;
            currentEnemySpawnIndex = 0;
            timeInCurrentEncounter = 0.0f;
            strength.Value = currentEncounter.InitialStrength;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isEncountersFinished)
            {
                timeInCurrentEncounter += Time.deltaTime;
                if (ShouldSpawnCurrentEnemySpawn())
                {
                    SpawnNextEnemies();
                }
            }
        }

        private void SpawnNextEnemies()
        {
            while (ShouldSpawnCurrentEnemySpawn())
            {
                SpawnEnemy();
                currentEnemySpawnIndex++;
                strength.Value = Mathf.Lerp(currentEncounter.InitialStrength, currentEncounter.MaxStrength, (float)(currentEnemySpawnIndex) / (currentEnemySpawns.Count - 1));
            }

            if (ShouldMoveToNextEncounter())
            {
                MoveToNextEncounter();
            }
        }

        private bool ShouldSpawnCurrentEnemySpawn()
        {
            if (currentEnemySpawnIndex < currentEnemySpawns.Count)
            {
                return timeInCurrentEncounter >= currentEnemySpawns[currentEnemySpawnIndex].SpawnTime;
            }
            else
            {
                return false;
            }
        }

        private void SpawnEnemy()
        {
            Debug.Assert(ShouldSpawnCurrentEnemySpawn(), "Spawning Enemy should not be spawned at this timepoint");
            EnemySpawnInstance enemySpawnInstance = currentEnemySpawns[currentEnemySpawnIndex];
            GameObject enemyPrefab = enemyDatabase.GetEnemy(enemySpawnInstance.EnemyID);
            Vector3 enemyPositon = transform.position;
            enemyPositon += new Vector3(enemySpawnInstance.SpawnLocationOffsetX, enemySpawnInstance.SpawnLocationOffsetY);
            activeEnemiesCount++;
            GameObject enemy = Instantiate(enemyPrefab, enemyPositon, Quaternion.identity);
            Debug.Assert(enemy != null, "Enemy not spawned");
        }

        private bool ShouldMoveToNextEncounter()
        {
            return currentEnemySpawnIndex >= currentEnemySpawns.Count && activeEnemiesCount <= 0;
        }

        private void MoveToNextEncounter()
        {
            Debug.Assert(ShouldMoveToNextEncounter(), "Moving to Encounter when it should not");
            currentEncounterCount.Value = currentEncounterCount.Value + 1;
            encounterFinished.Raise();
            if (currentEncounterCount.Value < maxEncounterCount.Value)
            {
                StartEncounter();
            }
            else
            {
                isEncountersFinished = true;
                allEncountersFinished.Raise();
            }
        }

        public void OnActiveEnemyDeath()
        {
            activeEnemiesCount--;
            if (ShouldMoveToNextEncounter())
            {
                MoveToNextEncounter();
            }
        }
    }
}

