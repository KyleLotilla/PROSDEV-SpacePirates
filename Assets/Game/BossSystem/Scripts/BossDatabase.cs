using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BossDatabase")]
    public class BossDatabase : ScriptableObject
    {
        [SerializeField]
        private List<GameObject> bossPrefabs;

        public IEnumerable<GameObject> Bosses
        {
            get
            {
                return bossPrefabs;
            }
        }

        public GameObject GetBoss(int id)
        {
            Debug.Assert(id >= 0 && id < bossPrefabs.Count, "BossDatabase: ID out of bound");
            if (id >= 0 && id < bossPrefabs.Count)
            {
                return bossPrefabs[id];
            }
            return null;
        }
    }
}

