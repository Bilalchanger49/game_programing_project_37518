using UnityEngine;
using UnityEngine.SceneManagement; // For restarting the game

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public GameObject gameOverUI; // Drag and drop your Game Over UI panel here

    void Awake()
    {
        // Set up the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        // Stop the game by setting time scale to 0
        Time.timeScale = 0f;

        // Show the Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }
    }

    public void RestartGame()
    {
        // Reset time scale before restarting
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
