using System.Collections.Generic;
using UnityEngine;
using CrossyRoad.Old;

namespace CrossyRoad.New
{
	public class GridLevelManager : MonoBehaviour
	{
		[SerializeField] private GridManager _gridManager;
		[SerializeField] private GridPlayer _player;
		[SerializeField] private GameObject _rowPrefab;
		[SerializeField] private GameObject _logLanePrefab; // Nouveau prefab LogLane
		[SerializeField] private float _logSpawnChance = 0.2f; // Chance de remplacer une ligne par un LogLane
		[SerializeField] private int _rowsCountAheadOfPlayer = 6;
		[SerializeField] private int _rowsCountBehindPlayer = 4;
		[SerializeField] private Transform _rowParent;
		[SerializeField] private GameObject _obstaclePrefab;
		[SerializeField] private GameObject _trainLanePrefab;
		[SerializeField] private float _trainLaneChance = 0.1f;
		[SerializeField] private GridCoinSpawner _coinSpawner;

		private Queue<GameObject> _activeRows = new();
		private int _currentRowY = 0;

		private void Start()
		{
			_player.PlayerChangedRow += OnPlayerChangedRow;

			InitGrid();
		}

		public void InitGrid()
		{
			for(int y = -_rowsCountBehindPlayer; y < 0; y++)
				SpawnRow(y);

			for (int y = 0; y < _rowsCountAheadOfPlayer + 1; y++)
				SpawnRow(y);

			_currentRowY = _rowsCountAheadOfPlayer;
		}

		private void OnPlayerChangedRow(int newY)
		{
			if (newY + _rowsCountAheadOfPlayer <= _currentRowY)
				return;

			_currentRowY++;
			SpawnRow(_currentRowY);
			RemoveOldestRow();
		}

		private void SpawnRow(int y)
		{
			Vector3 pos = _gridManager.GridToWorldPosition(new Vector2Int(0, y)).ToVector3FromXY(0f);

			GameObject row;

			if (y < 4)
			{
				row = Instantiate(_rowPrefab, pos, Quaternion.identity, _rowParent);
				_activeRows.Enqueue(row);
				return;
			}

			// On choisit entre une ligne normale ou une LogLane
			if (Random.value < _logSpawnChance)
			{
				row = Instantiate(_logLanePrefab, pos, Quaternion.identity, _rowParent);
			}
			else
			{
				row = Instantiate(_rowPrefab, pos, Quaternion.identity, _rowParent);
				TrySpawnObstacle(y, row);
			}

			if (Random.value < _trainLaneChance)
			{
				row = Instantiate(_trainLanePrefab, pos, Quaternion.identity, _rowParent);
			}

			_activeRows.Enqueue(row);

			_coinSpawner.SpawnCoinsOnRow(y);
		}

		// Deuxième version de SpawnRow en essayant d'éviter if/else, en utilisant une liste de règles pour choisir le type de ligne à générer
		// private void SpawnRow(int y)
		// {
		//     Vector3 pos = _gridManager.GridToWorldPosition(new Vector2Int(0, y)).ToVector3FromXY(0f);

		//     GameObject prefabToSpawn = GetRowPrefab(y);
		//     GameObject row = Instantiate(prefabToSpawn, pos, Quaternion.identity, _rowParent);

		//     if (prefabToSpawn == _rowPrefab)
		//         TrySpawnObstacle(y, row);

		//     _activeRows.Enqueue(row);
		// }

		// La méthode de sélection du prefab 
		// private GameObject GetRowPrefab(int y)
		// 
		//     List<(System.Func<int, bool> condition, GameObject prefab)> rules = new()
		//     {
		//         (i => i < 4, _rowPrefab),
		//         (i => Random.value < _logSpawnChance, _logLanePrefab),
		//         // Tu peux ajouter ici d'autres types (ex : train lane plus tard)
		//         (_ => true, _rowPrefab), // fallback
		//     };

		//     foreach (var (condition, prefab) in rules)
		//     {
		//         if (condition(y))
		//             return prefab;
		//     }

		//     return _rowPrefab; // sécurité
		// }
		private void RemoveOldestRow()
		{
			if (_activeRows.Count <= 0)
				return;

			GameObject oldest = _activeRows.Dequeue();
			Destroy(oldest);
		}

		private void TrySpawnObstacle(int rowY, GameObject parentRow)
		{
			if (Random.value > 0.5f) return;

			int randomX = Random.Range(-(_gridManager.Width / 2), (_gridManager.Width / 2) + 1);
			Vector2Int gridPos = new Vector2Int(randomX, rowY);
			Vector3 worldPos = _gridManager.GridToWorldPosition(gridPos).ToVector3FromXY(0.5f);

			Instantiate(_obstaclePrefab, worldPos, Quaternion.identity, parentRow.transform);
		}
	}
}