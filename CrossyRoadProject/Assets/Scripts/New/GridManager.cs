using UnityEngine;

namespace CrossyRoad.New
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int _width = 11;
        [SerializeField] private GameObject _tilePrefab;

        [SerializeField] private float _cellSize = 1f;

        //private void Start()
        //{
        //    GenerateGrid();
        //}

        //private void GenerateGrid()
        //{
        //    for (int x = 0; x < _width; x++)
        //    {
        //        for (int z = 0; z < _height; z++)
        //        {
        //            Vector3 pos = new Vector3(x * _cellSize, 0, z * _cellSize);
        //            Instantiate(_tilePrefab, pos, Quaternion.identity, transform);
        //        }
        //    }
        //}

        public Vector2 GridToWorldPosition(Vector2Int gridPosition)
        {
            return new Vector2(gridPosition.x * _cellSize, gridPosition.y * _cellSize);
        }

        public Vector2Int EvaluateWorldToGridPosition(Vector2 worldPosition)
        {
			return new(Mathf.RoundToInt(worldPosition.x / _cellSize), Mathf.RoundToInt(worldPosition.y / _cellSize));
		}

        public bool IsOnLeftBorder(Vector2Int gridPosition)
        {
            return gridPosition.x < -((_width - 1) / 2);
        }

        public bool IsOnLeftBorder(Vector2 worldPosition)
        {
            return IsOnLeftBorder(EvaluateWorldToGridPosition(worldPosition));
        }

        public bool IsOnRightBorder(Vector2Int gridPosition)
        {
			return gridPosition.x > ((_width - 1) / 2);
		}

		public bool IsOnRightBorder(Vector2 worldPosition)
		{
			return IsOnRightBorder(EvaluateWorldToGridPosition(worldPosition));
		}
	}
}
