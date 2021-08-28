using DLSU.SpacePirates.WeaponSystem;
using UnityEngine;

namespace DLSU.SpacePirates.Pickups
{
	public class AmmoDropper : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("Chance for the ammo to drop upon death.")]
		[Range(0f, 1f)]
		private float chance = 0.25f;
		[SerializeField]
		[Tooltip("Where the prefabs will be taken from.")]
		private WeaponDatabase database;

		/// <summary>
		/// Spawns the ammo directly on this object's position.
		/// </summary>
		private void Spawn()
		{
			if (database == null)
				return;

			GameObject instance = Instantiate(database.AmmoBoxPrefab);
			instance.transform.position = transform.position;
		}
	}
}