using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	public class ShootWeapon : MonoBehaviour
	{
		[Tooltip("Where all of the weapons are stored.")]
		[SerializeField]
		private WeaponDatabase database;
		[Tooltip("This weapon equipment.")]
		[SerializeField]
		private WeaponEquipment equipment;
		[Tooltip("The weapon's ship barrel sprite renderer.")]
		[SerializeField]
		private ShipBarrel shipBarrel;
		[Tooltip("Where the projectile will be spawned.")]
		[SerializeField]
		private Transform shipTip;
		[Tooltip("If this should ignore the weapon's ammunition. " +
			"This allows the weapon to be used even if " +
			"the ammunition is at 0.")]
		[SerializeField]
		private bool ignoreAmmo;
		[Tooltip("If the ammunition of the weapon is 0 after firing, " +
			"the weapon is replaced with the `WeaponDatabase` default weapon.")]
		[SerializeField]
		private bool useDefaultWeaponOnDepletion;
		/// <summary>
		/// This needs to be below or equal to 0f
		/// in order to fire.
		/// </summary>
		private float cooldown = 0f;

		public WeaponEquipment Equipment
		{
			get => equipment;
			private set => equipment = value;
		}

		/// <summary>
		/// Updates the ship's barrel sprite.
		/// </summary>
		public WeaponBarrel WeaponBarrel
		{
			set
			{
				if (shipBarrel != null)
					shipBarrel.WeaponBarrel = value;
			}
		}

		/// <summary>
		/// The weapon.
		/// Use this instead of the `WeaponEquipment`
		/// to also update the `ShipBarrel`.
		/// </summary>
		public Weapon Weapon
		{
			get => equipment.EquippedWeapon;
			set
			{
				equipment.EquippedWeapon = value;
				WeaponBarrel = value.Barrel;
			}
		}

		public bool OnCooldown => cooldown > 0f;

		/// <summary>
		/// If this weapon should be discarded.
		/// Primarily used to check if the weapon has ammo.
		/// </summary>
		public bool ShouldDiscard =>
			Equipment.Ammo <= 0 &&
			(Weapon == null || !Weapon.UnlimitedAmmo);

        private void Start()
        {
			Weapon = database.DefaultPlayerWeapon;
		}

		private void Update()
		{
			if (cooldown > 0f)
				cooldown -= Time.deltaTime;

			if (!OnCooldown &&
				(Input.GetMouseButton(0) || Input.GetKey(KeyCode.JoystickButton0)))
				Fire(shipTip.position, Vector2.right);
		}

		/// <summary>
		/// Fire a single projectile towards a target direction.
		/// </summary>
		/// <param name="origin">The initial position of the projectile.</param>
		/// <param name="direction">Where the projectile is going towards, in unit vector.</param>
		/// <returns>The projectile's GameObject.</returns>
		public virtual GameObject Fire(Vector2 origin, Vector2 direction)
		{
			if (cooldown > 0f)
				// On cooldown.
				return null;

			Weapon currentWeapon = Weapon;

			if (currentWeapon == null)
				// No weapon.
				return null;

			if (!ignoreAmmo && !currentWeapon.UnlimitedAmmo)
			{
				if (Equipment.Ammo - 1 <= 0 && useDefaultWeaponOnDepletion)
                {
					Weapon = database.DefaultPlayerWeapon;
				}
				else if (Equipment.Ammo - 1 <= 0)
                {
					return null;
				}
				// Decrease ammo.
				Equipment.Ammo--;
			}

			// Set on cooldown.
			cooldown = currentWeapon.FireRate;

			if (currentWeapon.ProjectilePrefab == null)
				// No projectile.
				return null;

			// Launch projectile.
			GameObject @object = Instantiate(currentWeapon.ProjectilePrefab, null);
			@object.transform.SetPositionAndRotation(
				origin,
				Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x))
			);

			if (shipBarrel != null)
            {
				shipBarrel.ShootBarrel();
            }

			return @object;
		}
	}
}