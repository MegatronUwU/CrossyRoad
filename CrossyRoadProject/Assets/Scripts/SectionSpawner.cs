using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private int _minObstacles = 1;
    [SerializeField] private int _maxObstacles = 4;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float xRangeFromPlayer = 1.5f;

    [SerializeField] private float _floorLength = 10f;

    [SerializeField] private Transform _triggerToMove;
    [SerializeField] private Vector3 _triggerLocalOffset;

    [SerializeField] private Transform _destroyTrigger;
    [SerializeField] private Vector3 _destroyTriggerOffset;



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // On décale le floor vers l'avant
        Vector3 spawnPos = new Vector3(0f, 0f, _spawnPoint.position.z + _floorLength);
        GameObject newFloor = Instantiate(_floorPrefab, spawnPos, _floorPrefab.transform.rotation);

        _triggerToMove.position = newFloor.transform.position + _triggerLocalOffset;
        _destroyTrigger.position = newFloor.transform.position + _destroyTriggerOffset;

        int obstacleCount = Random.Range(_minObstacles, _maxObstacles + 1);

        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 spawnPosObstacle = GetRandomPositionOnFloor(newFloor.transform);
            GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];

            Instantiate(obstaclePrefab, spawnPosObstacle, Quaternion.identity);
        }

        Debug.Log("Floor et obstacles générés");

    }

    private Vector3 GetRandomPositionOnFloor(Transform floor)
    {
        // On récupère la taille avec localScale
        Vector3 center = floor.position;
        Vector3 size = floor.localScale * 10f; 

        float x = Random.Range(center.x - size.x / 2f + 1f, center.x + size.x / 2f - 1f);
        float z = Random.Range(center.z - size.z / 2f + 1f, center.z + size.z / 2f - 1f);

        return new Vector3(x, center.y + 0.5f, z);
    }
}

