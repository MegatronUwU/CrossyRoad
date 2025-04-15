using UnityEngine;

namespace CrossyRoad.Old
{
	[CreateAssetMenu(fileName = "New Log Data", menuName = "ScriptableObjects/Log Data")]
	public class LogData : ScriptableObject
	{
		public float MovementSpeed = 1f;
	}
}