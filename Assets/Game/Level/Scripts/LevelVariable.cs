using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Level
{
    [CreateAssetMenu(menuName = "ScriptableObjects/LevelVariable")]
    public class LevelVariable : ScriptableObject
    {
        [SerializeField]
        private Level defaultValue;
        [SerializeField]
        private Level currentValue;
        public Level Value
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

