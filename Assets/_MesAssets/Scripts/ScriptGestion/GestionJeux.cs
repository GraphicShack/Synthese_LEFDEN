using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionJeux : MonoBehaviour
{
    private GestionUiJeux gestionUiJeux;
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] healthImages;

    public AudioClip damageSound; // Ajout du son de dommage

    private AudioSource audioSource; // R�f�rence � l'AudioSource

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();

        // Initialiser l'AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Si l'AudioSource n'est pas d�j� attach�, ajoutez-le au m�me GameObject
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        gestionUiJeux = FindObjectOfType<GestionUiJeux>();
    }

    private void UpdateHealthUI()
    {
        for (int i = 0; i < healthImages.Length; i++)
        {
            healthImages[i].enabled = i < currentHealth; // Activer l'image si i < currentHealth
        }
    }

    public void TakeDamage()
    {
        currentHealth--;

        // Jouer le son de dommage
        if (damageSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(damageSound);
        }

        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA");

        if (currentHealth <= 0)
        {
            gestionUiJeux.SauvegarderScoresTemporaires();
            // Appel de la m�thode pour sauvegarder avant de changer de sc�ne
            FindObjectOfType<GestionUiJeux>().ChangerDeScene("FinDePartie");
        }

        UpdateHealthUI();
    }
}
