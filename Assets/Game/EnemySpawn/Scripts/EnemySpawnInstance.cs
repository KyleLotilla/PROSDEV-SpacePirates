using System;
using UnityEngine;

namespace DLSU.SpacePirates.EnemySpawn
{
    [Serializable]
    public class EnemySpawnInstance
    {
        [SerializeField]
        private int enenmyID;
        public int EnemyID
        {
            get
            {
                return enenmyID;
            }
            set
            {
                enenmyID = value;
            }
        }

        [SerializeField]
        private float spawnTime;

        public float SpawnTime
        {
            get
            {
                return spawnTime;
            }
            set
            {
                spawnTime = value;
            }
        }

        [SerializeField]
        private float spawnLocationOffsetX;

        public float SpawnLocationOffsetX
        {
            get
            {
                return spawnLocationOffsetX;
            }
            set
            {
                spawnLocationOffsetX = value;
            }
        }

        [SerializeField]
        private float spawnLocationOffsetY;

        public float SpawnLocationOffsetY
        {
            get
            {
                return spawnLocationOffsetY;
            }
            set
            {
                spawnLocationOffsetY = value;
            }
        }
    }
}

