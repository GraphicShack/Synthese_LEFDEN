using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this line to use the UI components

public class GestionSon : MonoBehaviour
{
    private Sprite SoundOnImage;
    public Sprite SoundoffImage;
    public Button button; // Specify the type of the 'button' variable
    private bool isOn = true;

    public AudioSource audiosource;

    void Start()
    {
        SoundOnImage = button.image.sprite;
    }

    public void Buttonclicked()
    {
        if (isOn)
        {
            button.image.sprite = SoundoffImage;
            isOn = false;
            audiosource.mute = true;
        }
        else
        {
            button.image.sprite = SoundOnImage;
            isOn = true;
            audiosource.mute = false;
        }
    }
}
