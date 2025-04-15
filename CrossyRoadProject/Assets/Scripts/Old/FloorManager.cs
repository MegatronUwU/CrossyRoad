using UnityEngine;
using System.Collections.Generic;

namespace CrossyRoad.Old
{
	public class FloorManager : MonoBehaviour
	{
		public static FloorManager Instance;

		[SerializeField] private int maxFloors = 2;
		[SerializeField] private GameObject _baseFloor = null;

		private Queue<GameObject> _floorQueue = new Queue<GameObject>();

		private void Awake()
		{
			if (Instance == null) Instance = this;
			else Destroy(gameObject);

			_floorQueue.Enqueue(_baseFloor);
			_baseFloor.GetComponent<Floor>().GenerateObstacles();
		}

		public void RegisterFloor(GameObject floor)
		{
			_floorQueue.Enqueue(floor);

			// Si on dépasse le max, on supprime l’ancien
			if (_floorQueue.Count > maxFloors)
			{
				GameObject oldest = _floorQueue.Dequeue();
				Destroy(oldest);
			}
		}

		public void ClearAllFloors()
		{
			while (_floorQueue.Count > 0)
			{
				Destroy(_floorQueue.Dequeue());
			}
		}
	}
}