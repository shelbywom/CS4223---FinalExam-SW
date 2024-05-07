using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json; 

public class HighScoresDisplay : MonoBehaviour
{
    public string highScoresURL = "http://localhost/GetHighScores.php"; 
    public Text highScoresText; 

    void Start()
    {
        StartCoroutine(FetchHighScores()); 
    }

    private IEnumerator FetchHighScores()
    {
        UnityWebRequest www = UnityWebRequest.Get(highScoresURL);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error fetching high scores: " + www.error);
        }
        else
        {
            string responseText = www.downloadHandler.text; 
            List<HighScoreEntry> highScores = JsonConvert.DeserializeObject<List<HighScoreEntry>>(responseText);

            string displayText = "Top High Scores:\n";
            int rank = 1;

            foreach (HighScoreEntry entry in highScores)
            {
                string playerName = string.IsNullOrWhiteSpace(entry.PlayerName) ? "Unknown" : entry.PlayerName; 
                int score = entry.Score; 

                displayText += $"{rank}. {playerName} - {score}\n";
                rank++;
            }

            if (highScoresText != null)
            {
                highScoresText.text = displayText; 
            }
        }
    }
}

