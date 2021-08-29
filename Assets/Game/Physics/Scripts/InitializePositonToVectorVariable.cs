using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Physics
{
    public class InitializePositonToVectorVariable : MonoBehaviour
    {
        [SerializeField]
        private Vector2Variable vectorVariable;

        // Start is called before the first frame update
        void Start()
        {
            vectorVariable.Value = transform.position;
        }
    }

}
