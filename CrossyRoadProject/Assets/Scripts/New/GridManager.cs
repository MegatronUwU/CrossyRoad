using UnityEngine;

namespace CrossyRoad.New
{
    public class GridManager : MonoBehaviour
    {
        [SerializeField] private int _width = 10;
        [SerializeField] private int _height = 10;
        [SerializeField] private GameObject _tilePrefab;

        [SerializeField] private float _cellSize = 1f;

        private void Start()
        {
            GenerateGrid();
        }

        private void GenerateGrid()
        {
            for (int x = 0; x < _width; x++)
            {
                for (int z = 0; z < _height; z++)
                {
                    Vector3 pos = new Vector3(x * _cellSize, 0, z * _cellSize);
                    Instantiate(_tilePrefab, pos, Quaternion.identity, transform);
                }
            }
        }
    }
}
