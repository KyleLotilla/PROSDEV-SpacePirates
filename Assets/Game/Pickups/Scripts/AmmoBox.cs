using DLSU.SpacePirates.WeaponSystem;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.SpacePirates.Pickups
{
	/// <summary>
	/// Increases the player's ammunition upon collision.
	/// </summary>
	public class AmmoBox : MonoBehaviour
	{
		[SerializeField]
		private bool ignoreUnlimitedAmmoWeapons = true;
		[SerializeField]
		private UnityEvent onPickup;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			ShootWeapon shooter = collision.GetComponent<ShootWeapon>();

			if (shooter == null)
				return;

			if (shooter.Equipment.EquippedWeapon.UnlimitedAmmo &&
				ignoreUnlimitedAmmoWeapons)
				return;

			shooter.Equipment.AddRandomAmmo();
			onPickup.Invoke();
			Destroy(gameObject);
		}
	}
}