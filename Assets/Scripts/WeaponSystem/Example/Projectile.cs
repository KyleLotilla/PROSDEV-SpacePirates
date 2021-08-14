using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.Example
{
	/// <summary>
	/// This is an implementation example.// This is not meant to be used for production.
	/// </summary>
	public class Projectile : MonoBehaviour
	{
		private void Awake()
		{
			Destroy(gameObject, 10f);
		}

		private void Update()
		{
			transform.Translate(3f * Time.deltaTime * Vector3.right, Space.Self);
		}
	}
}