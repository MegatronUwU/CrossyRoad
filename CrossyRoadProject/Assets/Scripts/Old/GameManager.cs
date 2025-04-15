using UnityEngine;
using UnityEngine.SceneManagement;

namespace CrossyRoad.Old
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance;
		public GameObject gameOverCanvas;
		public GameObject GameUI;

		private void Awake()
		{
			if (Instance == null)
				Instance = this;
			else
				Destroy(gameObject);

			gameOverCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

		public void ShowGameOverUI()
		{
			Debug.Log("Game Over");
			//Time.timeScale = 0f;
			GameUI.SetActive(false);
			gameOverCanvas.SetActive(true);
		}

		public void RestartGame()
		{
			Debug.LogError("refiszhifesf");
			Time.timeScale = 1f;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}