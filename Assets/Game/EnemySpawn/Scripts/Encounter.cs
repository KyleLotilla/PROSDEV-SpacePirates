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
        private float initialStrength;

        public float InitialStrength
        {
            get
            {
                return initialStrength;
            }
            set
            {
                initialStrength = value;
            }
        }
        [SerializeField]
        private float maxStrength;
        public float MaxStrength
        {
            get
            {
                return maxStrength;
            }
            set
            {
                maxStrength = value;
            }
        }
        [SerializeField]
        private float duration;
        public float Duration
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;
            }
        }
        [SerializeField]
        private List<EnemySpawnInstance> enemySpawns;

        public List<EnemySpawnInstance> EnemySpawns
        {
            get
            {
                return enemySpawns;
            }
            set
            {
                enemySpawns = value;
            }
        }
    }
}

