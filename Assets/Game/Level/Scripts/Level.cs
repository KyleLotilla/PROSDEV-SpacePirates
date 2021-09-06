using System;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.EnemySpawn;
using DLSU.SpacePirates.BossSystem;

namespace DLSU.SpacePirates.Level
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Level")]
    public class Level : ScriptableObject
    {
        [SerializeField]
        private List<Encounter> encounters;

        public List<Encounter> Encounters
        {
            get
            {
                return encounters;
            }
            set
            {
                encounters = value;
            }
        }

        public int EncounterCount
        {
            get
            {
                return encounters.Count;
            }
        }

        [SerializeField]
        private BossSpawnInstance boss;

        public BossSpawnInstance Boss
        {
            get
            {
                return boss;
            }
            set
            {
                boss = value;
            }
        }

        [SerializeField]
        private Material background;

        public Material Background
        {
            get
            {
                return background;
            }
            set
            {
                background = value;
            }
        }

        [SerializeField]
        private Level nextLevel;
        public Level NextLevel
        {
            get
            {
                return nextLevel;
            }
            set
            {
                nextLevel = value;
            }
        }
    }
}

