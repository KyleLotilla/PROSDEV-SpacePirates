using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
    public class ShipBarrel : MonoBehaviour
    {
        [SerializeField]
        private Animator shipBarrelAnimator;
        private Vector2 originPosition;
        public WeaponBarrel WeaponBarrel
        {
            set
            {
                shipBarrelAnimator.runtimeAnimatorController = value.animatorController;
                Vector2 position = originPosition + value.positionOffset;
                transform.localPosition = position;
            }
        }

        private void Awake()
        {
            originPosition = transform.localPosition;
        }

        public void ShootBarrel()
        {
            shipBarrelAnimator.SetTrigger("shoot");
        }
    }

}
