using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    public InputField playerNameInputField; 

    public void OnPlayButtonClick()
    {
        GlobalData.PlayerName = playerNameInputField.text;

        SceneManager.LoadScene("Game");
    }
}
