using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.Interfaces
{
	public interface IProjectile
	{
		[SerializeField]
		Vector2 Direction { get; set; }
	}
}