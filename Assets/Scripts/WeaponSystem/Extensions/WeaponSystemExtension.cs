using DLSU.SpacePirates.WeaponSystem.Interfaces;

namespace DLSU.SpacePirates.WeaponSystem.Extensions
{
	public static class WeaponSystemExtension
	{
		/// <summary>
		/// Equips the weapon.
		/// The previous weapon is discarded.
		/// </summary>
		/// <param name="equipment">The equipment belonging to the receiver.</param>
		/// <param name="weapon">The weapon.</param>
		public static void PickUp(this IWeaponEquipment equipment, IWeaponPickUp weapon)
		{
			equipment.EquippedWeapon = new Weapon(weapon.Data);
		}

		/// <summary>
		/// Picks up the ammo.
		/// </summary>
		/// <param name="equipment">The equipment belonging to the receiver.</param>
		/// <param name="ammo">The ammo.</param>
		public static void PickUp(this IWeaponEquipment equipment, IAmmoPickUp ammo)
		{
			if (equipment.EquippedWeapon == null ||
				equipment.EquippedWeapon.Data != ammo.Data)
				// Incompatible weapon.
				return;

			equipment.EquippedWeapon.ammo += ammo.Amount;
		}
	}
}