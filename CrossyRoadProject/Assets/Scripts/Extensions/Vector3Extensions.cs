using UnityEngine;

namespace CrossyRoad.Old
{
	public static class Vector3Extensions
	{
		public static Vector3 AddZ(this Vector3 vector, float value)
		{
			return new Vector3(vector.x, vector.y, vector.z + value);
		}

		public static Vector3 SetX(this Vector3 vector, float value)
		{
			return new Vector3(value, vector.y, vector.z);
		}

		public static Vector2 ToVector2FromXZ(this Vector3 vector)
		{
			return new(vector.x, vector.z);
		}

		public static Vector3 ToVector3FromXY(this Vector2 vector, float y)
		{
			return new(vector.x, y, vector.y);
		}
	}
}