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
		public int ammo;
		[SerializeField]
		private Weapon equippedWeapon;
		[SerializeField]
		private GameEvent weaponChanged;

		public Weapon EquippedWeapon
		{
			get => equippedWeapon;
			set
			{
				equippedWeapon = value;
				ammo = value.RandomInitialAmmo;
				weaponChanged.Raise();
			}
		}

		public void AddAmmo(int amount)
		{
			if (equippedWeapon != null)
				ammo += amount;
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