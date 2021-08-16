using DLSU.SpacePirates.WeaponSystem.Interfaces;
using DLSU.SpacePirates.WeaponSystem.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace DLSU.SpacePirates.WeaponSystem.Example
{
	/// <summary>
	/// This is an implementation example.
	/// This is not meant to be used for production.
	/// </summary>
	public class WeaponSystemControllerExample : MonoBehaviour
	{
		[SerializeField]
		private WeaponDatabase database;
		[SerializeField]
		private Entity player;

		public WeaponDatabase Database => database;

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

				GameObject @object = Instantiate(controller.Database.WeaponPickUpPrefab);
				WeaponPickUp pickUp = @object.GetComponent<WeaponPickUp>();
				pickUp.Weapon = controller.Player.Shooter.Equipment.EquippedWeapon;
				@object.transform.position = Random.insideUnitCircle * 10f;
			}

			if (GUILayout.Button("Spawn Weapon"))
			{
				WeaponSystemControllerExample controller =
					Selection.activeGameObject.GetComponent<WeaponSystemControllerExample>();

				GameObject @object = Instantiate(controller.Database.WeaponPickUpPrefab);
				WeaponPickUp pickUp = @object.GetComponent<WeaponPickUp>();
				pickUp.Weapon = controller.Database.RandomWeapon;
				@object.transform.position = Random.insideUnitCircle * 10f;
			}
		}
	}
}