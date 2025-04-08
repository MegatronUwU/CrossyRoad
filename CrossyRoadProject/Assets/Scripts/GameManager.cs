using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Debug.Log("Game Over");

        Invoke("RestartGame", 2f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
