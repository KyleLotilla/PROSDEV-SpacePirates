using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.BossSystem
{
    public class BossSpawner : MonoBehaviour
    {
        [SerializeField]
        private BossDatabase bossDatabase;
        [SerializeField]
        private GameObjectVariable currentBoss;
        [SerializeField]
        private GameEvent bossSpawned;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnBoss(BossSpawnInstance bossSpawnInstance)
        {
            GameObject bossPrefab = bossDatabase.GetBoss(bossSpawnInstance.bossID);
            if (bossPrefab != null)
            {
                currentBoss.Value = Instantiate(bossPrefab, bossSpawnInstance.spawnPosition, bossSpawnInstance.spawnRotation);
                bossSpawned.Raise();
            }
        }
    }
}

