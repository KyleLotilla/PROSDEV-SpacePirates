using System;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.EnemySpawn;

namespace DLSU.SpacePirates.Level
{
    [Serializable]
    public class Level
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
    }
}

