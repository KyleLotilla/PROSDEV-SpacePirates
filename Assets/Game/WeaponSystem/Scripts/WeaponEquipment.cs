using UnityEngine;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.WeaponSystem
{
	[CreateAssetMenu(
		fileName = "WeaponEquipment",
		menuName = "ScriptableObjects/WeaponEquipment",
		order = 1
	)]
	public class WeaponEquipment : ScriptableObject
	{
		[SerializeField]
		private int ammo;
		[SerializeField]
		private Weapon equippedWeapon;
		[SerializeField]
		private GameEvent weaponChanged;
		[SerializeField]
		private GameEvent ammoChanged;

		public Weapon EquippedWeapon
		{
			get => equippedWeapon;
			set
			{
				equippedWeapon = value;
				Ammo = value.RandomInitialAmmo;
				weaponChanged.Raise();
			}
		}

		public int Ammo
        {
			get
            {
				return ammo;
            }
			set
            {
				ammo = value;
				ammoChanged.Raise();
			}
        }

		public void AddAmmo(int amount)
		{
			if (equippedWeapon != null)
            {
				ammo += amount;
				ammoChanged.Raise();
			}
		}

		public void AddRandomAmmo() =>
			AddAmmo(equippedWeapon.RandomAmmo);

        private void OnEnable()
        {
			equippedWeapon = null;
			ammo = 0;
		}
    }
}