using DLSU.SpacePirates.WeaponSystem.Data;
using DLSU.SpacePirates.WeaponSystem.Interfaces;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	/// <summary>
	/// This is an implementation example.
	/// </summary>
	public class Entity : MonoBehaviour, IWeaponEquipment
	{
		[SerializeField]
		private WeaponSystemData weaponSystemData;
		[SerializeField]
		private Weapon equippedWeapon;
		private float timer = 0.5f;

		public WeaponSystemData WeaponSystemData => weaponSystemData;

		public Weapon EquippedWeapon
		{
			get => equippedWeapon;
			set => equippedWeapon = value;
		}

		private void Update()
		{
			timer -= Time.deltaTime;

			if (timer > 0f)
				return;

			timer = 0.5f;

			if (EquippedWeapon == null)
				// Give the player the default weapon.
				EquippedWeapon = new Weapon(WeaponSystemData.DefaultPlayerWeaponData);

			if (EquippedWeapon == null)
				return;

			EquippedWeapon.Fire(transform.position, transform.right);

			if (EquippedWeapon.ShouldDiscard)
				EquippedWeapon = new Weapon(WeaponSystemData.DefaultPlayerWeaponData);
		}
	}
}