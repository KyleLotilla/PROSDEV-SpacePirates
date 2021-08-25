using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem
{
    [Serializable]
    public class BossSpawnInstance
    {
        public int bossID;
        public Vector2 spawnPosition;
        public Quaternion spawnRotation;
    }
}


