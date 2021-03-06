using UnityEngine;
using UnityEngine.Events;

namespace DLSU.SpacePirates.WeaponSystem
{
	/// <summary>
	/// A weapon that can be picked up on collision.
	/// </summary>
	public class WeaponPickUp : MonoBehaviour
	{
		[SerializeField]
		private Weapon weapon;
		[SerializeField]
		private SpriteRenderer iconRenderer;
		[SerializeField]
		private UnityEvent onPickup;
		public Weapon Weapon
		{
			get => weapon;
			set
			{
				weapon = value;

				if (weapon != null)
                {
					iconRenderer.sprite = weapon.Icon;
				}
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			ShootWeapon shooter = collision.GetComponent<ShootWeapon>();

			if (shooter == null)
				return;

			if (shooter.Equipment.EquippedWeapon == weapon)
            {
				shooter.Equipment.AddRandomAmmo();
			}
			else
            {
				shooter.Weapon = weapon;
			}

			onPickup.Invoke();
			Destroy(gameObject);
		}
	}
}