using UnityEngine;

namespace CrossyRoad.New
{
    public class TrainSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _trainPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float _delayBeforeTrain = 1.5f;

        private void Start()
        {
            Invoke(nameof(SpawnTrain), _delayBeforeTrain);
        }

        private void SpawnTrain()
        {
            Instantiate(_trainPrefab, _spawnPoint.position, Quaternion.identity, transform);
        }
    }
}
