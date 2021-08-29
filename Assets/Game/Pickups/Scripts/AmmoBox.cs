using DLSU.SpacePirates.WeaponSystem;
using UnityEngine;

namespace DLSU.SpacePirates.Pickups
{
	/// <summary>
	/// Increases the player's ammunition upon collision.
	/// </summary>
	public class AmmoBox : MonoBehaviour
	{
		[SerializeField]
		private bool ignoreUnlimitedAmmoWeapons = true;

		private void OnTriggerEnter2D(Collider2D collision)
		{
			ShootWeapon shooter = collision.GetComponent<ShootWeapon>();

			if (shooter == null)
				return;

			if (shooter.Equipment.EquippedWeapon.UnlimitedAmmo &&
				ignoreUnlimitedAmmoWeapons)
				return;

			shooter.Equipment.AddRandomAmmo();
			Destroy(gameObject);
		}
	}
}