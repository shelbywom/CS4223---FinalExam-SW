using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    public DatabaseHandler databaseHandler; 
    public string exitSceneName = "Exit"; 

    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void GoToExit()
    {
        if (databaseHandler != null)
        {
            databaseHandler.AddScoreToDatabase();
        }

        SceneManager.LoadScene(exitSceneName);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Exits the compiled game
#endif
    }
}
