using System.Collections.Generic;
using UnityEngine;
using CrossyRoad.Old;

namespace CrossyRoad.New
{
    public class GridLevelManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GameObject _rowPrefab;
        [SerializeField] private GameObject _logLanePrefab; // Nouveau prefab LogLane
        [SerializeField] private float _logSpawnChance = 0.2f; // Chance de remplacer une ligne par un LogLane
        [SerializeField] private int _initialRows = 6;
        [SerializeField] private Transform _rowParent;
        [SerializeField] private GameObject _obstaclePrefab;

        private Queue<GameObject> _activeRows = new();
        private int _currentRowY = 0;

        public void InitGrid()
        {
            for (int y = 0; y < _initialRows; y++)
            {
                SpawnRow(y);
            }
            _currentRowY = _initialRows - 1;
        }

        public void TryAdvanceRow(int playerGridY)
        {
            if (playerGridY <= _currentRowY - 2) return;

            _currentRowY++;
            SpawnRow(_currentRowY);
            RemoveOldestRow();
        }

        private void SpawnRow(int y)
        {
            Vector3 pos = _gridManager.GridToWorldPosition(new Vector2Int(0, y)).ToVector3FromXY(0f);

            GameObject row;

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

            _activeRows.Enqueue(row);
        }

        private void RemoveOldestRow()
        {
            if (_activeRows.Count > 0)
            {
                GameObject oldest = _activeRows.Dequeue();
                Destroy(oldest);
            }
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
