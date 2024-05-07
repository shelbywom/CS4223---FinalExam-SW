using UnityEngine;
using UnityEngine.UI;

public class PlayerColorController : MonoBehaviour
{
    public Dropdown colorDropdown; 
    public Renderer playerRenderer; 

    private Color defaultColor = new Color(15 / 255f, 243 / 255f, 25 / 255f, 1f); 
    private Color pink = new Color(1, 0, 1); // Bright pink
    private Color blue = new Color(0, 0, 1); // Bold blue
    private Color metallic = new Color(0.75f, 0.75f, 0.75f); // Metallic

    void Start()
    {
        UpdatePlayerColor(colorDropdown.value);
        colorDropdown.onValueChanged.AddListener(UpdatePlayerColor);
    }

    void UpdatePlayerColor(int index)
    {
        if (playerRenderer != null)
        {
            switch (index)
            {
                case 0: // Default option
                    playerRenderer.material.color = defaultColor;
                    break;
                case 1: // Pink
                    playerRenderer.material.color = pink;
                    break;
                case 2: // Blue
                    playerRenderer.material.color = blue;
                    break;
                case 3: // Metallic
                    playerRenderer.material.color = metallic;
                    break;
                default:
                    break;
            }
        }
    }
}
