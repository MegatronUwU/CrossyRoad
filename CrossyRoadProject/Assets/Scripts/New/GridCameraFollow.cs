using UnityEngine;

namespace CrossyRoad.New
{
	public class GridCameraMovement : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private Vector3 _offset = new Vector3(0, 18, -15);
		[SerializeField] private float _followSpeed = 5f;

		private void LateUpdate()
		{
			if (_target == null) return;

			// On calcule la position cible de la cam�ra par rapport � la grille
			Vector3 targetPosition = _target.position + _offset;
			transform.position = Vector3.Lerp(transform.position, targetPosition, _followSpeed * Time.deltaTime);
		}
	}
}
