using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.EnemySpawn
{
    [Serializable]
    public class Encounter
    {
        [SerializeField]
        public float initialStrength;
        [SerializeField]
        public float maxStrength;
        [SerializeField]
        public List<EnemySpawnInstance> enemySpawns;
    }
}

