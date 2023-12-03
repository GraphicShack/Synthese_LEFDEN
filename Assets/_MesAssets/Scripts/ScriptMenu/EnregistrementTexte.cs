using UnityEngine;
using TMPro;

public class EnregistrementTexte : MonoBehaviour
{
    public TMP_InputField inputField;

    private const string clePlayerPrefs = "NomJoueur"; // Modifier la clé pour le nom du joueur

    private void Start()
    {
        // Charger le texte enregistré lors du démarrage du jeu
        ChargerNomJoueurEnregistre();
    }

    public void SauvegarderNomJoueur()
    {
        string nomJoueurSaisi = inputField.text;

        // Enregistrer le nom du joueur dans PlayerPrefs
        PlayerPrefs.SetString(clePlayerPrefs, nomJoueurSaisi);
        PlayerPrefs.Save();

        Debug.Log("Nom du joueur enregistré : " + nomJoueurSaisi);
    }

    private void ChargerNomJoueurEnregistre()
    {
        // Charger le nom du joueur enregistré depuis PlayerPrefs
        if (PlayerPrefs.HasKey(clePlayerPrefs))
        {
            string nomJoueurEnregistre = PlayerPrefs.GetString(clePlayerPrefs);
            inputField.text = nomJoueurEnregistre;

            Debug.Log("Nom du joueur chargé : " + nomJoueurEnregistre);
        }
    }
}
