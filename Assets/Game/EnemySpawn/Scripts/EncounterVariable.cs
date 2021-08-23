using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.EnemySpawn
{
    [CreateAssetMenu(menuName = "ScriptableObjects/EncounterVariable")]
    public class EncounterVariable : ScriptableObject
    {
        [SerializeField]
        private Encounter defaultValue;
        [SerializeField]
        private Encounter currentValue;
        public Encounter Value
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
