using DLSU.SpacePirates.WeaponSystem.Data;
using UnityEditor;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem
{
	/// <summary>
	/// This is an implementation example.
	/// </summary>
	public class WeaponSystemControllerExample : MonoBehaviour
	{
		[SerializeField]
		private WeaponSystemData data;
		[SerializeField]
		private Entity player;

		public WeaponSystemData Data => data;

		public Entity Player => player;
	}

	[CustomEditor(typeof(WeaponSystemControllerExample))]
	public class WeaponSystemControllerExample_Editor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();

			if (GUILayout.Button("Spawn Ammo For Equipped"))
			{
				WeaponSystemControllerExample controller =
					Selection.activeGameObject.GetComponent<WeaponSystemControllerExample>();
				controller.Data.SpawnAmmoPickUp(controller.Player.EquippedWeapon.Data, Random.insideUnitCircle * 10f);
			}

			if (GUILayout.Button("Spawn Weapon"))
			{
				WeaponSystemControllerExample controller =
					Selection.activeGameObject.GetComponent<WeaponSystemControllerExample>();
				controller.Data.SpawnWeaponPickUp(controller.Data.RandomWeaponData, Random.insideUnitCircle * 10f);
			}
		}
	}
}