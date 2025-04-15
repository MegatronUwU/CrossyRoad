using UnityEngine;

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
}
