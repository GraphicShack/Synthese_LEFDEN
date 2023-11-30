using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Son : MonoBehaviour
{
    public Sprite spriteActive;
    public Sprite spriteDesactive;
    public AudioSource audioSource;

    private Image image;
    private Button bouton;

    private void Start()
    {
        image = GetComponent<Image>();
        bouton = GetComponent<Button>();

        // Assurez-vous que l'audioSource est correctement configur� dans l'�diteur Unity
        if (audioSource == null)
        {
            Debug.LogError("AudioSource non d�fini pour le bouton son.");
        }

        // Ajoutez un �couteur d'�v�nement au bouton pour d�tecter les clics
        if (bouton != null)
        {
            bouton.onClick.AddListener(ToggleSon);
        }

        // Mettez � jour le sprite initial
        UpdateSprite();
    }

    public void ToggleSon()
    {
        // Inverse l'�tat du son (activ�/d�sactiv�)
        audioSource.mute = !audioSource.mute;

        // Met � jour le sprite en fonction de l'�tat du son
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        // Met � jour le sprite en fonction de l'�tat du son
        if (audioSource.mute)
        {
            image.sprite = spriteDesactive;
        }
        else
        {
            image.sprite = spriteActive;
        }
    }
}