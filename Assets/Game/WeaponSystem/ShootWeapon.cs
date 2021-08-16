using DLSU.SpacePirates.WeaponSystem.ScriptableObjects;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	public class ShootWeapon : MonoBehaviour
	{
		[SerializeField]
		private WeaponEquipment equipment;

		public WeaponEquipment Equipment
		{
			get => equipment;
			private set => equipment = value;
		}

		/// <summary>
		/// If this weapon should be discarded.
		/// Primarily used to check if the weapon has ammo.
		/// </summary>
		public bool ShouldDiscard =>
			Equipment.ammo <= 0 &&
			(Equipment.EquippedWeapon == null || !Equipment.EquippedWeapon.UnlimitedAmmo);

		/// <summary>
		/// Fire a single projectile towards a target direction.
		/// </summary>
		/// <param name="origin">The initial position of the projectile.</param>
		/// <param name="direction">Where the projectile is going towards, in unit vector.</param>
		/// <returns>The projectile's GameObject.</returns>
		public virtual GameObject Fire(Vector2 origin, Vector2 direction, bool ignoreAmmo = false)
		{
			Weapon weapon = Equipment.EquippedWeapon;

			if (weapon == null)
				return null;

			if (!ignoreAmmo && !weapon.UnlimitedAmmo)
			{
				if (Equipment.ammo <= 0)
					// Insufficient ammo!
					return null;

				Equipment.ammo--;
			}

			if (weapon.ProjectilePrefab == null)
				return null;

			GameObject @object = Instantiate(weapon.ProjectilePrefab, null);
			@object.transform.position = origin;
			@object.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x));
			return @object;
		}
	}
}