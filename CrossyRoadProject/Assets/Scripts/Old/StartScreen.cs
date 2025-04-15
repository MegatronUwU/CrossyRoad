using UnityEngine;
using UnityEngine.InputSystem;

namespace CrossyRoad.Old
{
	public class StartScreen : MonoBehaviour
	{
		public GameObject startCanvas;
		public GameObject gameCanvas;
		public GameObject player;

		private bool hasStarted = false;
		private InputSystem_Actions _actions;

		private void Awake()
		{
			_actions = new InputSystem_Actions();
		}

		private void OnEnable()
		{
			_actions.Enable();
			_actions.Player.Enable();
			_actions.Player.Attack.Enable();
			_actions.Player.Attack.performed += OnClickToStart;
		}

		private void OnDisable()
		{
			_actions.Player.Attack.performed -= OnClickToStart;
			_actions.Disable();
		}

		void OnClickToStart(InputAction.CallbackContext ctx)
		{
			if (hasStarted) return;

			hasStarted = true;

			startCanvas.SetActive(false);
			gameCanvas.SetActive(true);
			player.SetActive(true);
		}
	}
}