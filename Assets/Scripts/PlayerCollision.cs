using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class PlayerCollision : MonoBehaviour
{
    public int score = 0; 
    public Text scoreText; 
    public static int remainingTargets = 5; 
    public DatabaseHandler databaseHandler; 
    public string exitSceneName = "Exit"; 

    void Start()
    {
        remainingTargets = 5; 
        UpdateScoreText(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target")) 
        {
            Destroy(collision.gameObject); 
            score++; 
            remainingTargets--; 
            UpdateScoreText(); 
            CheckTargets(); 
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null) 
        {
            scoreText.text = "Score: " + score; 
        }
    }

    void CheckTargets()
    {
        if (remainingTargets == 0) 
        {
            Debug.Log("All targets destroyed. Transitioning to Exit.");
            if (databaseHandler != null)
            {
                databaseHandler.AddScoreToDatabase(); 
            }

            SceneManager.LoadScene(exitSceneName); 
        }
    }
}

