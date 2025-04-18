using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrossyRoad.New
{
	public class GridPlayerCollisionHandler : MonoBehaviour
	{
		[SerializeField] private LogData _logData = null;

		private int _connectedLogCount = 0;
		public bool IsOnLog => _connectedLogCount > 0;

		private int _connectedWaterCount = 0;
		public bool IsOnWater => _connectedWaterCount > 0;

		private void Update()
		{
			if (!IsOnLog)
				return;

			transform.Translate(Vector3.right * _logData.MovementSpeed * Time.deltaTime);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Water"))
			{
				_connectedWaterCount++;
				return;
			}

			if (other.CompareTag("Log"))
				_connectedLogCount++;
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.CompareTag("Water"))
				_connectedWaterCount--;

			if (other.CompareTag("Log"))
				_connectedLogCount--;
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.CompareTag("Obstacle"))
			{
				if (GameManager.Instance == null)
					return;

				GameManager.Instance.ShowGameOverUI();
			}
		}
	}
}
