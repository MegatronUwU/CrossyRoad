using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    private bool _isOnLog = false;
    private Transform _currentLog = null;

    [SerializeField] private LogController _currentLogController;

    private void Update()
    {
        // Si on est sur un log, on suit son mouvement
        if (_isOnLog && _currentLog != null && _currentLogController != null)
        {
            Vector3 move = _currentLog.right * Time.deltaTime * _currentLogController.Speed;
            transform.position += move;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //  On check l'eau uniquement si on n'est pas sur un log
        if (other.CompareTag("Water") && !_isOnLog)
        {
            Debug.Log("Game Over");
            GameManager.Instance.ShowGameOverUI();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0f;
            GameManager.Instance.ShowGameOverUI();
        }
    }

    public void SetIsOnLog(bool value, Transform logTransform = null, LogController logController = null)
    {
        _isOnLog = value;
        _currentLog = logTransform;
        _currentLogController = logController;
    }
}
