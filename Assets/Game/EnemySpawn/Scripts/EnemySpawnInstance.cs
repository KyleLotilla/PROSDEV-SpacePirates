using System;
using UnityEngine;

namespace DLSU.SpacePirates.EnemySpawn
{
    [Serializable]
    public class EnemySpawnInstance
    {
        [SerializeField]
        public int enemyID;
        [SerializeField]
        [Tooltip("The time that elpased after the encounter has started when the enemy will spawn. 0 means it will spawn instantly")]
        public float spawnDelayTime;
        [SerializeField]
        [Tooltip("The absolute world position that the enemy will spawn at")]
        public Vector2 spawnPosition;
        [SerializeField]
        [Tooltip("The rotation that the enemy will spawn with")]
        public Quaternion spawnRotation;
    }
}

