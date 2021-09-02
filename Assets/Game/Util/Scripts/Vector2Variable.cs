using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Util
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Vector2Variable")]
    public class Vector2Variable : ScriptableObject
    {
        public Vector2 defaultValue;
        [SerializeField]
        private Vector2 currentValue;
        public Vector2 Value
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
    }
}
