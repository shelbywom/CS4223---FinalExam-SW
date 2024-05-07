using UnityEngine;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    public Text nameText; 

    void Start()
    {
        nameText.text = GlobalData.PlayerName;
    }
}
