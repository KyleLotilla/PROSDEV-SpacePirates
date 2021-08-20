﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.EnemySpawn
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField]
        private GameEvent activeEnemyDeath;

        private void OnDestroy()
        {
            activeEnemyDeath.Raise();
        }
    }
}
