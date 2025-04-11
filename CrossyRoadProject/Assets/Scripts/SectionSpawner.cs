using UnityEngine;
using System.Collections.Generic;

public class SectionSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject[] _obstaclePrefabs;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private int _minObstacles = 6;
    [SerializeField] private int _maxObstacles = 8;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float xRangeFromPlayer = 1.5f;

    [SerializeField] private float _floorLength = 10f;

    [SerializeField] private Transform _triggerToMove;
    [SerializeField] private Vector3 _triggerLocalOffset;

    [SerializeField] private Transform _destroyTrigger;
    [SerializeField] private Vector3 _destroyTriggerOffset;

    [SerializeField] private float _minDistance = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // On décale le floor vers l'avant
        Vector3 spawnPos = new Vector3(0f, 0f, _spawnPoint.position.z + _floorLength);
        GameObject newFloor = Instantiate(_floorPrefab, spawnPos, _floorPrefab.transform.rotation);
        FloorManager.Instance.RegisterFloor(newFloor);

        newFloor.GetComponent<Floor>().GenerateObstacles();

        _triggerToMove.position = newFloor.transform.position + _triggerLocalOffset;
        _destroyTrigger.position = newFloor.transform.position + _destroyTriggerOffset;

        int obstacleCount = Random.Range(_minObstacles, _maxObstacles + 1);

        List<Vector3> usedPositions = new List<Vector3>();
        int attempts = 0;

        for (int i = 0; i < obstacleCount && attempts < 100; attempts++)
        {
            Vector3 spawnPosObstacle = GetRandomPositionOnFloor(newFloor.transform);

            // On check s'ils sont pas trop proche
            bool tooClose = false;
            foreach (var pos in usedPositions)
            {
                if (Vector3.Distance(spawnPosObstacle, pos) < _minDistance)
                {
                    tooClose = true;
                    break;
                }
            }

            if (tooClose) continue;

            GameObject obstaclePrefab = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)];
            //Instantiate(obstaclePrefab, spawnPosObstacle, Quaternion.identity);
            usedPositions.Add(spawnPosObstacle);
            i++;
        }

        Debug.Log("Floor et obstacles générés");
    }

    private Vector3 GetRandomPositionOnFloor(Transform floor)
    {
        // On récupère la taille avec localScale
        Vector3 center = floor.position;
        float playerX = _playerTransform.position.z;

        // On fait spawn à côté du player
        float x = Random.Range(playerX - xRangeFromPlayer, playerX + xRangeFromPlayer);

        float zMin = center.z - (_floorLength / 2f) + 1f;
        float zMax = center.z + (_floorLength / 2f) - 1f;
        float z = Random.Range(zMin, zMax);

        return new Vector3(x, center.y + 0.5f, z);
    }
}
