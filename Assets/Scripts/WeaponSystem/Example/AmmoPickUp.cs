using DLSU.SpacePirates.WeaponSystem.Data;
using DLSU.SpacePirates.WeaponSystem.Extensions;
using DLSU.SpacePirates.WeaponSystem.Interfaces;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	/// <summary>
	/// This is an implementation example.
	/// </summary>
	public class AmmoPickUp : MonoBehaviour, IAmmoPickUp
	{
		[SerializeField]
		private WeaponData data;
		[SerializeField]
		private int amount;

		public WeaponData Data
		{
			get => data;
			set => data = value;
		}

		public int Amount
		{
			get => amount;
			set => amount = value;
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			IWeaponEquipment equipment = collision.GetComponent<IWeaponEquipment>();

			if (equipment == null)
				return;

			equipment.PickUp(this);
			Destroy(gameObject);
		}
	}
}