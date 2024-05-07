using UnityEngine;
using UnityEngine.UI;

public class PlayerSizeController : MonoBehaviour
{
    public Slider sizeSlider; 
    public GameObject player;
    public Text playerSizeText; 


    void Start()
    {
        UpdatePlayerSize(sizeSlider.value);

        sizeSlider.onValueChanged.AddListener(UpdatePlayerSize);
    }

    void UpdatePlayerSize(float newSize)
    {
        player.transform.localScale = new Vector3(newSize, newSize, newSize);
        playerSizeText.text = $"Size: {newSize:F2}";
    }
}
