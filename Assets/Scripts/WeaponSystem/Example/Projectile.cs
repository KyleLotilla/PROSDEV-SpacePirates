using DLSU.SpacePirates.WeaponSystem.Interfaces;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	/// <summary>
	/// This is an implementation example.
	/// </summary>
	public class Projectile : MonoBehaviour, IProjectile
	{
		public Vector2 Direction { get; set; }

		private void Awake()
		{
			Destroy(gameObject, 10f);
			transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(Direction.y, Direction.x));
		}

		private void Update()
		{
			transform.Translate(3f * Time.deltaTime * Direction);
		}
	}
}