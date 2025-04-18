using UnityEngine;
using UnityEngine.InputSystem;

namespace CrossyRoad.Old
{
	public class PlayerMovement : MonoBehaviour
	{
		public float moveDistance = 1f;
		public float moveDuration = 0.1f;

		private bool isMoving = false;
		private InputSystem_Actions _actions;

		[SerializeField]
		private PlayerCollisionHandler _collisionHandler = null;


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
			if (isMoving) return;

			Vector2 input = ctx.ReadValue<Vector2>();
			Vector3 direction = Vector3.zero;

			// On check la direction en fonction de l'input
			if (input.y > 0) direction = Vector3.forward;
			else if (input.y < 0) direction = Vector3.back;
			else if (input.x < 0) direction = Vector3.left;
			else if (input.x > 0) direction = Vector3.right;

			// On lance la coroutine pour animer le déplacement
			if (direction != Vector3.zero)
				StartCoroutine(MoveToPosition(transform.position + direction * moveDistance));
		}

		private System.Collections.IEnumerator MoveToPosition(Vector3 target)
		{
			isMoving = true;
			Vector3 start = transform.position;
			float elapsed = 0f;

			// Pour animer le déplacement
			while (elapsed < moveDuration)
			{
				transform.position = Vector3.Lerp(start, target, elapsed / moveDuration);
				elapsed += Time.deltaTime;
				yield return null;
			}

			transform.position = target;
			isMoving = false;

			if (!_collisionHandler.IsOnLog && _collisionHandler.IsOnWater)
			{
				Time.timeScale = 0f;
				GameManager.Instance.ShowGameOverUI();
			}
		}

		public void Move(Vector3 direction)
		{
			if (isMoving) return;
			StartCoroutine(MoveToPosition(transform.position + direction * moveDistance));
		}

	}
}