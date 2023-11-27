using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionJeux : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public Image[] healthImages;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
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

        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAA");

        if (currentHealth <= 0)
        {
            // Appel de la méthode pour sauvegarder avant de changer de scène
            FindObjectOfType<GestionUiJeux>().ChangerDeScene("FinDePartie");
        }

        UpdateHealthUI();
    }
}