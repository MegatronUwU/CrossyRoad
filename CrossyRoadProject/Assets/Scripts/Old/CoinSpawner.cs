using UnityEngine;

namespace CrossyRoad.Old
{
	public class CoinSpawner : MonoBehaviour
	{
		public GameObject CoinPrefab;
		public Renderer FloorRenderer; // Exposé dans l'inspector
		public int CoinCount = 5;

		private void Start()
		{
			SpawnCoins();
		}

		private void SpawnCoins()
		{
			Vector3 floorSize = FloorRenderer.bounds.size;
			Vector3 floorCenter = FloorRenderer.bounds.center;

			for (int i = 0; i < CoinCount; i++)
			{
				float randomX = Random.Range(floorCenter.x - floorSize.x / 2f, floorCenter.x + floorSize.x / 2f);
				float randomZ = Random.Range(floorCenter.z - floorSize.z / 2f, floorCenter.z + floorSize.z / 2f);

				Vector3 spawnPos = new Vector3(randomX, FloorRenderer.transform.position.y + 0.5f, randomZ);
				Instantiate(CoinPrefab, spawnPos, Quaternion.identity);
			}
		}
	}
}