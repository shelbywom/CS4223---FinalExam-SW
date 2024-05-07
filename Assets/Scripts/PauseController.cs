using UnityEngine;
using UnityEngine.UI; // For UI components

public class PauseController : MonoBehaviour
{
    public GameObject pausePanel; // Reference to the PausePanel GameObject
    private bool isPaused = false; // Track if the game is paused

    void Start()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false); // Initially hide the pause panel
        }
    }

    void Update()
    {
        // Check if the "P" key is pressed to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
        isPaused = true;
        if (pausePanel != null)
        {
            pausePanel.SetActive(true); // Show the pause panel
        }
        Debug.Log("Game paused.");
    }

    void ResumeGame()
    {
        Time.timeScale = 1; // Resume the game
        isPaused = false;
        if (pausePanel != null)
        {
            pausePanel.SetActive(false); // Hide the pause panel
        }
        Debug.Log("Game resumed.");
    }
}
