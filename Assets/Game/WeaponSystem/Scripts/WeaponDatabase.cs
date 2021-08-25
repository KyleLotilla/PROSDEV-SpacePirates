using DLSU.SpacePirates.WeaponSystem.Utilities;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	[CreateAssetMenu(
		fileName = "WeaponDatabase",
		menuName = "ScriptableObjects/WeaponDatabase",
		order = 1
	)]
	public class WeaponDatabase : ScriptableObject
	{
		[SerializeField]
		[Tooltip("List of weapons available in the game.")]
		private List<WeaponRegistry> registries = new List<WeaponRegistry>();
		[SerializeField]
		[Tooltip("The prefab that will be used for weapon pick-ups.")]
		private GameObject weaponPickUpPrefab;
		[SerializeField]
		[Tooltip("The ammo box prefab.")]
		private GameObject ammoBoxPrefab;
		[SerializeField]
		[Tooltip("The weapon that the player will receive when " +
			"their current weapon is out of ammo. " +
			"Weapons without any ammo is discarded. " +
			"This is always given to the player regardless " +
			"if it does not have an unlimited ammo.")]
		private Weapon defaultPlayerWeapon;

		public GameObject WeaponPickUpPrefab => weaponPickUpPrefab;

		public GameObject AmmoBoxPrefab => ammoBoxPrefab;

		public Weapon DefaultPlayerWeapon => defaultPlayerWeapon;

		/// <summary>
		/// References a weapon in the database.
		/// </summary>
		public Weapon this[int id]
		{
			get
			{
				foreach (WeaponRegistry registry in registries)
					if (registry.id == id)
						return registry.weapon;

				return null;
			}

			set
			{
				registries.RemoveAll(v => v.id == id);
				registries.Add(new WeaponRegistry(id, value));
			}
		}

		/// <summary>
		/// Returns a random weapon data registered.
		/// </summary>
		public Weapon RandomWeapon
		{
			get
			{
				if (registries.Count == 0)
					return null;

				if (registries.Count == 1)
					return registries[0].weapon;

				return registries[Random.Range(0, registries.Count)].weapon;
			}
		}

		/// <summary>
		/// Removes all weapons with the given ids.
		/// </summary>
		/// <returns>Number of weapons successfully removed.</returns>
		public int Unregister(params int[] ids) =>
			registries.RemoveAll(v => ids.Contains(v.id));

		private void OnValidate()
		{
			Dictionary<int, int> ids = new Dictionary<int, int>();

			foreach (WeaponRegistry registry in registries)
			{
				if (registry.weapon == null)
					Debug.LogError($"Weapon Registry #{registry.id} is empty!");

				if (ids.ContainsKey(registry.id))
					ids[registry.id]++;
				else
					ids[registry.id] = 1;
			}

			foreach (KeyValuePair<int, int> pair in ids)
				if (pair.Value > 1)
					Debug.LogError($"Weapon ID #{pair.Key} registry has more than 1 occurrences! ({pair.Value} registries.)");
		}
	}
}