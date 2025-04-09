using System;
using UnityEngine;

public class LogController : MonoBehaviour
{
	[SerializeField] private LogData _logData = null;
	public float MinX = -10f;
	public float MaxX = 10f;

	[SerializeField] public PlayerCollisionHandler _playerHandler;

	private void Update()
	{
		Vector3 direction = Vector3.right * _logData.MovementSpeed * Time.deltaTime;

		transform.Translate(direction);

		if (transform.position.x > MaxX)
		{
			Vector3 newPos = transform.position;
			newPos.x = MinX;
			transform.position = newPos;
		}
	}

}