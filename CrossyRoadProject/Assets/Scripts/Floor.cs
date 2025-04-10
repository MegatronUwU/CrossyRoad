using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
	[SerializeField] private Transform[] _obstacleSpawnPoints;
	[SerializeField] private Transform[] _obstaclePrefabs;
	[SerializeField] private Transform _logPrefab;

	private Transform[] _generatedObstacles;

	public void GenerateObstacles()
	{
		_generatedObstacles = new Transform[_obstacleSpawnPoints.Length];

		for (int i = 0; i < _obstacleSpawnPoints.Length; i++)
		{
			_generatedObstacles[i] = Instantiate(_obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)], _obstacleSpawnPoints[i].position, Quaternion.identity, transform);

			if (_generatedObstacles[i].TryGetComponent<LogController>(out _))
			{
				_generatedObstacles[i + 1] = Instantiate(_logPrefab, _obstacleSpawnPoints[i].position, Quaternion.identity, transform);
				_generatedObstacles[i + 2] = Instantiate(_logPrefab, _obstacleSpawnPoints[i].position, Quaternion.identity, transform);
				_generatedObstacles[i + 3] = Instantiate(_logPrefab, _obstacleSpawnPoints[i].position, Quaternion.identity, transform);
				i += 3;
			}
		}

		PrintInfo();

		foreach (Transform obstacleTransform in _obstacleSpawnPoints)
		{

		}
	}

	private void PrintInfo()
	{

	}
}