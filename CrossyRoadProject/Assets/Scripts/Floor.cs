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
			Vector3 spawnPos = _obstacleSpawnPoints[i].position + Vector3.up * .25f; 
			_generatedObstacles[i] = Instantiate(_obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Length)], spawnPos, Quaternion.identity, transform);

			if(_generatedObstacles[i].GetComponentInChildren<LogController>() != null)
			{
				_generatedObstacles[i] = Instantiate(_logPrefab, spawnPos.AddZ(1.5f), Quaternion.identity, transform);
				_generatedObstacles[i] = Instantiate(_logPrefab, spawnPos.AddZ(3f), Quaternion.identity, transform);
				//_generatedObstacles[i] = Instantiate(_logPrefab, spawnPos.AddZ(4.5f), Quaternion.identity, transform);
				i++;
				i++;
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