using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem
{
    [CreateAssetMenu(menuName = "ScriptableObjects/BossSpawnInstanceVariable")]
    public class BossSpawnInstanceVariable : ScriptableObject
    {
        [SerializeField]
        private BossSpawnInstance defaultValue;
        [SerializeField]
        private BossSpawnInstance currentValue;
        public BossSpawnInstance Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }
        }

        private void OnEnable()
        {
            if (currentValue == null)
            {
                currentValue = defaultValue;
            }
        }
    }
}
