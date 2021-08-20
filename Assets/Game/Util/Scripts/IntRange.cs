using System;

namespace DLSU.SpacePirates.WeaponSystem.Utilities
{
	/// <summary>
	/// Similar to `UnityEngine.RangeInt`, but this one is serialized.
	/// </summary>
	[Serializable]
	public struct IntRange
	{
		public int min;
		public int max;

		public IntRange(int min, int max)
		{
			this.min = min;
			this.max = max;
		}

		/// <summary>
		/// Picks a random number between `min` and `max`.
		/// </summary>
		public int Random => UnityEngine.Random.Range(min, max + 1);
	}
}