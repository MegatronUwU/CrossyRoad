using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrossyRoad.New
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private GameObject _gameOverCanvas;

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;

            _gameOverCanvas.SetActive(false); 
        }

        public void ShowGameOverUI()
        {
            _gameOverCanvas.SetActive(true);
            Time.timeScale = 0f; 
        }

        public void RestartGame()
        {
            Time.timeScale = 1f; 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}