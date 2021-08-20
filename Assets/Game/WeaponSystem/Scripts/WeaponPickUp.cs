using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	/// <summary>
	/// A weapon that can be picked up on collision.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(Collider2D))]
	[RequireComponent(typeof(SpriteRenderer))]
	public class WeaponPickUp : MonoBehaviour
	{
		[SerializeField]
		private Weapon weapon;
		[SerializeField]
		private SpriteRenderer icon;

		public Weapon Weapon
		{
			get => weapon;
			set
			{
				weapon = value;
				icon.sprite = weapon.Sprite;
			}
		}

		private void Awake()
		{
			icon = GetComponent<SpriteRenderer>();
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			ShootWeapon shooter = collision.GetComponent<ShootWeapon>();

			if (shooter == null)
				return;

			if (shooter.Equipment.EquippedWeapon == weapon)
				shooter.Equipment.AddRandomAmmo();
			else
				shooter.Equipment.EquippedWeapon = weapon;

			Destroy(gameObject);
		}
	}
}