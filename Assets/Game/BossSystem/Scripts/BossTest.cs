using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem
{
    public class BossTest : MonoBehaviour
    {
        [SerializeField]
        private BossSpawnInstanceVariable testBoss;
        [SerializeField]
        private BossSpawner bossSpawner;
        // Start is called before the first frame update
        void Start()
        {
            bossSpawner.SpawnBoss(testBoss.Value);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

