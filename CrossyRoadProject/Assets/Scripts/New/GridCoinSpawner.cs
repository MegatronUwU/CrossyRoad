using UnityEngine;
using CrossyRoad.Old;

namespace CrossyRoad.New
{
    public class GridCoinSpawner : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GameObject _coinPrefab;
        [SerializeField] private Transform _coinParent;
        [SerializeField] private int _spawnPerRow = 1;

        public void SpawnCoinsOnRow(int rowY)
        {
            for (int i = 0; i < _spawnPerRow; i++)
            {
                int randomX = Random.Range(-(_gridManager.Width / 2), (_gridManager.Width / 2) + 1);
                Vector2Int gridPos = new Vector2Int(randomX, rowY);
                Vector3 worldPos = _gridManager.GridToWorldPosition(gridPos).ToVector3FromXY(0.5f);

                Instantiate(_coinPrefab, worldPos, Quaternion.identity, _coinParent);
            }
        }
    }
}
