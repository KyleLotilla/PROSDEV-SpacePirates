using DLSU.SpacePirates.WeaponSystem.Utilities;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.ScriptableObjects
{
	[CreateAssetMenu(
		fileName = "Weapon",
		menuName = "ScriptableObjects/Weapon",
		order = 1
	)]
	public class Weapon : ScriptableObject
	{
		[Tooltip("Sprite for this weapon.")]
		[SerializeField]
		private Sprite sprite;
		[Tooltip("Projectile prefab for this weapon.")]
		[SerializeField]
		private GameObject projectilePrefab;
		[Tooltip("If this weapon has unlimited ammo.")]
		[SerializeField]
		private bool unlimitedAmmo = false;
		[Tooltip("Initial ammo on weapon pick-up.")]
		[SerializeField]
		private IntRange[] initialAmmoRanges = new IntRange[]
		{
			new IntRange(20, 30)
		};
		[Tooltip("Ranges of ammunition quantity that can drop.")]
		[SerializeField]
		private IntRange[] ammoRanges = new IntRange[]
		{
			new IntRange(10, 20)
		};

		public Sprite Sprite => sprite;

		public GameObject ProjectilePrefab => projectilePrefab;

		public bool UnlimitedAmmo => unlimitedAmmo;

		/// <summary>
		/// Pick a random number from one of the initial ammo ranges.
		/// </summary>
		public int RandomInitialAmmo =>
			initialAmmoRanges != null && initialAmmoRanges.Length > 0
			? initialAmmoRanges[Random.Range(0, initialAmmoRanges.Length)].Random
			: 0;

		/// <summary>
		/// Pick a random number from one of the ammo ranges.
		/// </summary>
		public int RandomAmmo =>
			ammoRanges != null && ammoRanges.Length > 0
			? ammoRanges[Random.Range(0, ammoRanges.Length)].Random
			: 0;
	}
}