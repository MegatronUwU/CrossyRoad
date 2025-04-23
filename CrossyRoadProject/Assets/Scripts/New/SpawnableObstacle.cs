using System.Collections.Generic;
using UnityEngine;

namespace CrossyRoad.New
{
	[CreateAssetMenu(fileName = "New Spawnable Obstacle", menuName = "ScriptableObjects/Spawnable Obstacle")]
	public class SpawnableObstacle : ScriptableObject
    {
		public GameObject ObstaclePrefab = null;
		public float Weight = 1;
		[Space]
		public int AdditionalObstaclesMinQuantity = 0;
		public int AdditionalObstaclesMaxQuantity = 0;
		public GameObject AdditionalObstaclePrefab = null;
	}
}
