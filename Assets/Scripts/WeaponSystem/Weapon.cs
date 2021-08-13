using DLSU.SpacePirates.WeaponSystem.Data;
using DLSU.SpacePirates.WeaponSystem.Interfaces;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	public class Weapon
	{
		public int ammo;

		public WeaponData Data { get; protected set; }

		/// <summary>
		/// If this weapon should be discarded.
		/// Primarily used to check if the weapon has ammo.
		/// </summary>
		public bool ShouldDiscard => ammo <= 0 && !Data.UnlimitedAmmo;

		public Weapon(WeaponData data)
		{
			Data = data;
			ammo = data.RandomInitialAmmo;
		}

		/// <summary>
		/// Fire a single projectile towards a target direction.
		/// </summary>
		/// <param name="origin">The initial position of the projectile.</param>
		/// <param name="direction">Where the projectile is going towards, in unit vector.</param>
		/// <returns>The GameObject.</returns>
		public virtual GameObject Fire(Vector2 origin, Vector2 direction, bool ignoreAmmo = false)
		{
			WeaponData data = Data;

			if (!ignoreAmmo && !data.UnlimitedAmmo)
			{
				if (ammo <= 0)
					// Insufficient ammo!
					return null;

				ammo--;
			}

			if (data.ProjectilePrefab == null)
				return null;

			GameObject @object = Object.Instantiate(data.ProjectilePrefab, null);
			IProjectile projectile = @object.GetComponent<IProjectile>();

			if (projectile == null)
				// Invalid projectile prefab!
				return @object;

			@object.transform.position = origin;
			projectile.Direction = direction;
			return @object;
		}
	}
}