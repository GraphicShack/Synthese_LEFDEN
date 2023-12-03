using UnityEngine;
using TMPro;

public class AnimationTexteMenu : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public float animationSpeed = 1f;
    public float minFontSize = 80f;
    public float maxFontSize = 90f;

    private bool increasingFontSize = true;

    void Update()
    {
        // Calculate the new font size based on the animation speed
        float deltaSize = animationSpeed * Time.deltaTime;

        // Update the font size based on the animation direction
        if (increasingFontSize)
        {
            textMeshProUGUI.fontSize = Mathf.Min(textMeshProUGUI.fontSize + deltaSize, maxFontSize);

            // Change direction when reaching the maximum size
            if (textMeshProUGUI.fontSize >= maxFontSize)
            {
                increasingFontSize = false;
            }
        }
        else
        {
            textMeshProUGUI.fontSize = Mathf.Max(textMeshProUGUI.fontSize - deltaSize, minFontSize);

            // Change direction when reaching the minimum size
            if (textMeshProUGUI.fontSize <= minFontSize)
            {
                increasingFontSize = true;
            }
        }
    }
}
