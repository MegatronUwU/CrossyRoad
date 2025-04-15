using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using CrossyRoad.Old;

namespace CrossyRoad.New
{
	public class GridPlayer : MonoBehaviour
	{
		//[SerializeField] private float _moveDistance = 1f;
		[SerializeField] private float _moveCooldown = 0.15f;

		[SerializeField] private GridManager _gridManager = null;

		private bool _isMoving = false;

		private InputSystem_Actions _actions;

		private void Awake()
		{
			_actions = new InputSystem_Actions();
		}

		private void Start()
		{
			transform.position = _gridManager.GridToWorldPosition(Vector2Int.zero).ToVector3FromXY(1f);
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
			if (_isMoving)
				return;

			Vector2 input = ctx.ReadValue<Vector2>();
			Vector2 direction = Vector3.zero;

			// On check la direction en fonction de l'input
			if (input.y > 0) direction = Vector2.up;
			else if (input.y < 0) direction = Vector2.down;
			else if (input.x < 0) direction = Vector2.left;
			else if (input.x > 0) direction = Vector2.right;

			if (direction == Vector2.zero)
				return;

			//StartCoroutine(MoveToPosition(transform.position + direction * _moveDistance));

			Vector2Int gridTargetPosition = _gridManager.EvaluateWorldToGridPosition(transform.position.ToVector2FromXZ() + direction);

			if (direction == Vector2.left && _gridManager.IsOnLeftBorder(gridTargetPosition))
				return;

			if (direction == Vector2.right && _gridManager.IsOnRightBorder(gridTargetPosition))
				return;

			Vector3 worlTargetPosition = _gridManager.GridToWorldPosition(gridTargetPosition).ToVector3FromXY(1f);
			StartCoroutine(MoveToPosition(worlTargetPosition));
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
				elapsed += Time.deltaTime * 2f;
				yield return null;
			}

			transform.position = targetPosition;
			_isMoving = false;
		}
	}
}
