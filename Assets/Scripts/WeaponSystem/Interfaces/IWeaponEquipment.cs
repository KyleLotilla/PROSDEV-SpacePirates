using DLSU.SpacePirates.WeaponSystem.Data;

namespace DLSU.SpacePirates.WeaponSystem.Interfaces
{
	public interface IWeaponEquipment
	{
		WeaponSystemData WeaponSystemData { get; }

		Weapon EquippedWeapon { get; set; }
	}
}