using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DLSU.SpacePirates.WeaponSystem;

namespace DLSU.SpacePirates.HUD
{
    public class WeaponHUD : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private WeaponEquipment weaponEquipment;

        [SerializeField]
        private Image weaponIcon;

        [SerializeField]
        private TextMeshProUGUI ammoText;

        [SerializeField]
        private TextMeshProUGUI weaponNameText;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        }

        public void UpdateWeapon()
        {
            weaponIcon.sprite = weaponEquipment.EquippedWeapon.Icon;
            weaponNameText.text = weaponEquipment.EquippedWeapon.WeaponName;
        }

        public void UpdateAmmo()
        {
            if (weaponEquipment.EquippedWeapon.UnlimitedAmmo)
            {
                ammoText.text = "\u221E";
            }
            else
            {
                ammoText.text = weaponEquipment.Ammo.ToString();
            }
        }
    }
}


