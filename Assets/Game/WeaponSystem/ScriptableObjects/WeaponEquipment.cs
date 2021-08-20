using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.ScriptableObjects
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

		public Weapon EquippedWeapon
		{
			get => equippedWeapon;
			set
			{
				equippedWeapon = value;
				ammo = value.RandomInitialAmmo;
			}
		}

		public void AddAmmo(int amount)
		{
			if (equippedWeapon != null)
				ammo += amount;
		}

		public void AddRandomAmmo() =>
			AddAmmo(equippedWeapon.RandomAmmo);
	}
}