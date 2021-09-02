using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.EnemySpawn
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField]
        private GameEvent activeEnemyDeath;

        public void RaiseEnemyDeath()
        {
            activeEnemyDeath.Raise();
        }
    }
}

