using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Threading.Tasks;

public class PlayerMovement : MonoBehaviour
{
    public float MoveDistance = 1f;
    public float moveDuration = 0.1f;

    private bool isMoving = false;
    private InputSystem_Actions _actions;

    private void Awake()
    {
        _actions = new InputSystem_Actions();

        Random.Range(0, 5);
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

    Coroutine coroutine;

	private async void OnMove(InputAction.CallbackContext ctx)
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
            coroutine = StartCoroutine(MoveToPosition(transform.position + direction * MoveDistance));

        StopCoroutine(coroutine);
    }

    private IEnumerator MoveToPosition(Vector3 target)
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
    }
}