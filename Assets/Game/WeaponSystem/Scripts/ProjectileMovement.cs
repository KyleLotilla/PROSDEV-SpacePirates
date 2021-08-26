using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D projectileRigidbody;
        [SerializeField]
        private Vector2 velocity;

        void Start()
        {
            projectileRigidbody.velocity = velocity;
        }

    }
}


