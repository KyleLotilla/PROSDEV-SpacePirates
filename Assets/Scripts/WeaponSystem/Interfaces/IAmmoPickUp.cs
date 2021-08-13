using DLSU.SpacePirates.WeaponSystem.Data;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.Interfaces
{
	public interface IAmmoPickUp
	{
		/// <summary>
		/// This is automatically set by the WeaponSystemData,
		/// but you can still change it if you want.
		/// </summary>
		[SerializeField]
		WeaponData Data { get; set; }

		/// <summary>
		/// This is automatically set by the WeaponSystemData,
		/// but you can still change it if you want.
		/// </summary>
		[SerializeField]
		int Amount { get; set; }
	}
}