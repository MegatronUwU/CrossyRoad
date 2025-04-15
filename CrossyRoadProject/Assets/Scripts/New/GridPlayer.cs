using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; 

namespace CrossyRoad.New
{
	public class GridPlayer : MonoBehaviour
	{
		[SerializeField] private float _moveDistance = 1f;
		[SerializeField] private float _moveCooldown = 0.15f;

		private bool _isMoving = false;
		private float _lastMoveTime;

		private InputSystem_Actions _actions;

		private void Awake()
		{
			_actions = new InputSystem_Actions();
		}

		private void OnEnable()
		{
			_actions.Enable();
			_actions.Player.Move.performed += OnMove;
		}

		private void OnDisable()
		{
			_actions.Player.Move.performed -= OnMove;
			_actions.Disable();
		}

		private void OnMove(InputAction.CallbackContext ctx)
		{
			// On empêche un déplacement s’il y en a déjà un + petit cooldown 
			if (_isMoving || Time.time - _lastMoveTime < _moveCooldown) return;

			Vector2 input = ctx.ReadValue<Vector2>();
			Vector3 direction = Vector3.zero;

			// On check la direction en fonction de l'input
			if (input.y > 0) direction = Vector3.forward;
			else if (input.y < 0) direction = Vector3.back;
			else if (input.x < 0) direction = Vector3.left;
			else if (input.x > 0) direction = Vector3.right;

			if (direction != Vector3.zero)
				StartCoroutine(MoveToPosition(transform.position + direction * _moveDistance));
		}

		private IEnumerator MoveToPosition(Vector3 targetPosition)
		{
			_isMoving = true;
			Vector3 startPosition = transform.position;
			float elapsed = 0f;

			// Pour animer le déplacement
			while (elapsed < _moveCooldown)
			{
				transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / _moveCooldown);
				elapsed += Time.deltaTime;
				yield return null;
			}

			transform.position = targetPosition;
			_isMoving = false;
			_lastMoveTime = Time.time;
		}
	}
}
