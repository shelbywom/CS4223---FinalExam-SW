using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour
{
    public InputField playerNameInputField; 

    public void SetPlayerName()
    {
        if (playerNameInputField != null)
        {
            GlobalData.PlayerName = playerNameInputField.text; 
        }
    }
}
