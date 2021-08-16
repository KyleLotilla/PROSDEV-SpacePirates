using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.EnemySpawn
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EnemyDatabase")]
    public class EnemyDatabase : ScriptableObject
    {
        [SerializeField]
        private List<GameObject> enemyPrefabs;

        public GameObject GetEnemy(int id)
        {
            Debug.Assert(id >= 0 && id < enemyPrefabs.Count, "EnemyDatabase: ID out of bound");
            if (id >= 0 && id < enemyPrefabs.Count)
            {
                return enemyPrefabs[id];
            }
            return null;
        }
    }
}
