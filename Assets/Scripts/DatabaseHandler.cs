using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DatabaseHandler : MonoBehaviour
{
    public string databaseURL = "http://localhost/AddScore"; 
    public PlayerCollision playerCollision; 

    public void AddScoreToDatabase()
    {
        StartCoroutine(SendScoreToDatabase());
    }

    private IEnumerator SendScoreToDatabase()
    {
        if (playerCollision == null)
        {
            Debug.LogError("PlayerCollision reference is missing. Cannot send score.");
            yield break; 
        }

        WWWForm form = new WWWForm();
        form.AddField("PlayerName", GlobalData.PlayerName);
        form.AddField("Score", playerCollision.score); 

        UnityWebRequest www = UnityWebRequest.Post(databaseURL, form);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error sending score to database: " + www.error);
        }
        else
        {
            Debug.Log("Score successfully added to the database.");
        }
    }
}
