using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Util
{
    [CreateAssetMenu(menuName = "ScriptableObjects/GameObjectVariable")]
    public class GameObjectVariable : ScriptableObject
    {
        public GameObject defaultValue;
        [SerializeField]
        private GameObject currentValue;
        public GameObject Value
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
            currentValue = defaultValue;
        }

        private void OnDisable()
        {
            currentValue = null;
        }
    }
}
