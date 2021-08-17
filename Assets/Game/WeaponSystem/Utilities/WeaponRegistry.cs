using DLSU.SpacePirates.WeaponSystem.ScriptableObjects;
using System;

namespace DLSU.SpacePirates.WeaponSystem.Utilities
{
	/// <summary>
	/// A ID-Weapon pair.
	/// </summary>
	[Serializable]
	public struct WeaponRegistry
	{
		public int id;
		public Weapon weapon;

		public WeaponRegistry(int id, Weapon weapon)
		{
			this.id = id;
			this.weapon = weapon;
		}
	}
}