using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    private bool _isOnLog = false;

    private void OnTriggerEnter(Collider other)
    {
        // On check avant si c'est un log
        if (other.CompareTag("Log"))
        {
            _isOnLog = true;
            transform.SetParent(other.transform); 
        }

        //  On check l'eau uniquement si on n'est pas sur un log
        if (other.CompareTag("Water") && !_isOnLog)
        {
            Debug.Log("Game Over");
            GameManager.Instance.ShowGameOverUI();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Log"))
        {
            _isOnLog = false;
            transform.SetParent(null); 
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

    public void SetIsOnLog(bool value)
    {
        _isOnLog = value;
    }
}
