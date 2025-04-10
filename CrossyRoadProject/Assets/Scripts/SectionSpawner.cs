using UnityEngine;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _minObstacles = 1;
    [SerializeField] private int _maxObstacles = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // On centre le floor pour éviter que ça soit décaler
        Vector3 spawnPos = new Vector3(0f, 0f, _spawnPoint.position.z);
        GameObject newFloor = Instantiate(_floorPrefab, spawnPos, _floorPrefab.transform.rotation);

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
