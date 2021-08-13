using DLSU.SpacePirates.WeaponSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.Data
{
	[CreateAssetMenu(
		fileName = "WeaponSystemData",
		menuName = "ScriptableObjects/WeaponSystemData",
		order = 1
	)]
	public class WeaponSystemData : ScriptableObject
	{
		[SerializeField]
		[Tooltip("List of weapons available in the game.")]
		private List<WeaponData> weaponData = new List<WeaponData>();
		[SerializeField]
		[Tooltip("The weapon that the player will receive when " +
			"their current weapon is out of ammo. " +
			"Weapons without any ammo is discarded. " +
			"This is always given to the player regardless " +
			"if it does not have an unlimited ammo.")]
		private WeaponData defaultPlayerWeaponData;

		public WeaponData DefaultPlayerWeaponData => defaultPlayerWeaponData;

		/// <summary>
		/// Returns a random weapon data registered.
		/// </summary>
		public WeaponData RandomWeaponData =>
			weaponData.Count == 0
			? null
			: weaponData[UnityEngine.Random.Range(0, weaponData.Count)];

		/// <summary>
		/// Returns the first weapon data that has the same name,
		/// otherwise `null`.
		/// </summary>
		public WeaponData WeaponFromName(string name, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) =>
			weaponData.FirstOrDefault(v => v.name.Equals(name, comparisonType));

		/// <summary>
		/// Spawns a random weapon with its pick-up prefab.
		/// </summary>
		public GameObject SpawnWeaponPickUp(WeaponData data, Vector2 position)
		{
			if (data == null)
				return null;

			if (data.PickUpPrefab == null)
				return null;

			GameObject @object = Instantiate(data.PickUpPrefab, null);
			@object.transform.position = position;
			IWeaponPickUp pickUp = @object.GetComponent<IWeaponPickUp>();

			if (pickUp != null)
				pickUp.Data = data;

			return @object;
		}

		/// <summary>
		/// Short-hand for `SpawnAmmoPickUp(WeaponData, WeaponData.RandomAmmo, Vector2)`.
		/// </summary>
		public GameObject SpawnAmmoPickUp(WeaponData data, Vector2 position) =>
			SpawnAmmoPickUp(data, data.RandomAmmo, position);

		/// <summary>
		/// Spawns a random ammo for a weapon with its ammo pick-up prefab.
		/// </summary>
		public GameObject SpawnAmmoPickUp(WeaponData data, int amount, Vector2 position)
		{
			if (data == null)
				return null;

			if (data.PickUpPrefab == null)
				return null;

			GameObject @object = Instantiate(data.PickUpPrefab, null);
			@object.transform.position = position;
			IAmmoPickUp pickUp = @object.GetComponent<IAmmoPickUp>();

			if (pickUp != null)
			{
				pickUp.Data = data;
				pickUp.Amount = amount;
			}

			return @object;
		}

		/// <summary>
		/// Register the weapon data into the list.
		/// </summary>
		public void Register(params WeaponData[] datas)
		{
			foreach (WeaponData data in datas)
				weaponData.Add(data);
		}

		/// <summary>
		/// Removes the weapon prefabs from the list.
		/// </summary>
		/// <returns>Number of prefabs successfully removed.</returns>
		public int Unregister(params WeaponData[] datas)
		{
			int i = 0;

			foreach (WeaponData data in datas)
				if (weaponData.Remove(data))
					i++;

			return i;
		}
	}
}