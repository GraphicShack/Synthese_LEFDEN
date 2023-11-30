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

        // Assurez-vous que l'audioSource est correctement configuré dans l'éditeur Unity
        if (audioSource == null)
        {
            Debug.LogError("AudioSource non défini pour le bouton son.");
        }

        // Ajoutez un écouteur d'événement au bouton pour détecter les clics
        if (bouton != null)
        {
            bouton.onClick.AddListener(ToggleSon);
        }

        // Mettez à jour le sprite initial
        UpdateSprite();
    }

    public void ToggleSon()
    {
        // Inverse l'état du son (activé/désactivé)
        audioSource.mute = !audioSource.mute;

        // Met à jour le sprite en fonction de l'état du son
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        // Met à jour le sprite en fonction de l'état du son
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