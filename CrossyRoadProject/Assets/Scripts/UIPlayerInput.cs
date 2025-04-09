using UnityEngine;

public class UIPlayerInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    public void MoveUp() => _playerMovement.Move(Vector3.forward);
    public void MoveDown() => _playerMovement.Move(Vector3.back);
    public void MoveLeft() => _playerMovement.Move(Vector3.left);
    public void MoveRight() => _playerMovement.Move(Vector3.right);
}
