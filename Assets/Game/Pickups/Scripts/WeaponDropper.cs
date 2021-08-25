using DLSU.SpacePirates.WeaponSystem;
using UnityEngine;

namespace DLSU.SpacePirates.Pickups
{
	public class WeaponDropper : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The weapon that will be dropped.")]
		private Weapon weapon;
		[SerializeField]
		[Tooltip("Where the prefabs will be taken from.")]
		private WeaponDatabase database;

		/// <summary>
		/// Spawns the weapon directly on this object's position.
		/// </summary>
		private void Spawn()
		{
			if (weapon == null || database == null)
				return;

			GameObject instance = Instantiate(database.WeaponPickUpPrefab);
			instance.GetComponent<WeaponPickUp>().Weapon = weapon;
			instance.transform.position = transform.position;
		}
	}
}