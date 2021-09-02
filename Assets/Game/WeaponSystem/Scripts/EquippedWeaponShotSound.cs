using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
    public class EquippedWeaponShotSound : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private WeaponEquipment weaponEquipment;

        public void OnWeaponChanged()
        {
            audioSource.clip = weaponEquipment.EquippedWeapon.ShotSound;
        }
    }
}

