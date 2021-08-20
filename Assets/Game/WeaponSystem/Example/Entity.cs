using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.Example
{
	/// <summary>
	/// This is an implementation example.
	/// This is not meant to be used for production.
	/// </summary>
	[RequireComponent(typeof(ShootWeapon))]
	public class Entity : MonoBehaviour
	{
		[SerializeField]
		private WeaponDatabase weaponDatabase;
		private float timer = 0.5f;

		public ShootWeapon Shooter { get; private set; }

		public WeaponDatabase WeaponDatabase => weaponDatabase;

		private void Awake()
		{
			Shooter = GetComponent<ShootWeapon>();
		}

		private void Update()
		{
			timer -= Time.deltaTime;

			if (timer > 0f)
				return;

			timer = 0.5f;

			if (Shooter.Equipment.EquippedWeapon == null)
				// Give the player the default weapon.
				Shooter.Equipment.EquippedWeapon = WeaponDatabase.DefaultPlayerWeapon;

			if (Shooter.Equipment.EquippedWeapon == null)
				return;

			Shooter.Fire(transform.position, transform.right);

			if (Shooter.ShouldDiscard)
				Shooter.Equipment.EquippedWeapon = WeaponDatabase.DefaultPlayerWeapon;
		}
	}
}