using System.Collections.Generic;
using UnityEngine;
using CrossyRoad.Old;

namespace CrossyRoad.New
{
    public class GridLevelManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GameObject _rowPrefab;
        [SerializeField] private int _initialRows = 6;
        [SerializeField] private Transform _rowParent;

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
            if (playerGridY <= _currentRowY - 1) return;

            _currentRowY++;
            SpawnRow(_currentRowY);
            RemoveOldestRow();
        }

        private void SpawnRow(int y)
        {
            Vector3 pos = _gridManager.GridToWorldPosition(new Vector2Int(0, y)).ToVector3FromXY(0f);
            GameObject row = Instantiate(_rowPrefab, pos, Quaternion.identity, _rowParent);
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
    }
}
