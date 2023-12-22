using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionUiFinDePartie : MonoBehaviour
{
    public TextMeshProUGUI tempsText;
    public TextMeshProUGUI tirText;
    public TextMeshProUGUI ennemiAbattuText;
    public TextMeshProUGUI scoreFinalText;
    public TextMeshProUGUI nomJoueurText;

    private void Start()
    {
        // Récupérer le score final
        int scoreFinal = GetScoreFinal();

        // Appeler UpdateMeilleurScore de ScoreManager avec le nouveau score final
        FindObjectOfType<ScoreManager>().UpdateMeilleurScore(scoreFinal);

        // Charger le nom du joueur enregistré
        ChargerNomJoueurEnregistre();

        // Récupérer les scores sauvegardés temporairement
        int tempsDeJeu = PlayerPrefs.GetInt("TempsDeJeu", 0);
        int tirs = PlayerPrefs.GetInt("Tirs", 0);
        int ennemisAbattus = PlayerPrefs.GetInt("EnnemisAbattus", 0);

        // Afficher les scores dans les TextMeshProUGUI
        tempsText.text = "Temps : " + tempsDeJeu;
        tirText.text = "Tir : " + tirs;
        ennemiAbattuText.text = "Ennemi abattu : " + ennemisAbattus;
        scoreFinalText.text = "Score Final : " + scoreFinal;

        // Effacer les valeurs sauvegardées
        PlayerPrefs.DeleteKey("NomJoueur");
        PlayerPrefs.DeleteKey("TempsDeJeu");
        PlayerPrefs.DeleteKey("Tirs");
        PlayerPrefs.DeleteKey("EnnemisAbattus");
        PlayerPrefs.DeleteKey("ScoreFinal");
        PlayerPrefs.Save();

        // ... Autres actions de votre Start() existant
    }

    // Ajoutez cette méthode pour obtenir le score final
    private int GetScoreFinal()
    {
        int tempsDeJeu = PlayerPrefs.GetInt("TempsDeJeu", 0);
        int tirs = PlayerPrefs.GetInt("Tirs", 0);
        int ennemisAbattus = PlayerPrefs.GetInt("EnnemisAbattus", 0);

        int scoreFinal = tempsDeJeu + (10 * ennemisAbattus) - tirs;
        return scoreFinal;
    }

    // Ajoutez cette méthode pour charger le nom du joueur enregistré
    private void ChargerNomJoueurEnregistre()
    {
        if (PlayerPrefs.HasKey("NomJoueur"))
        {
            string nomJoueurEnregistre = PlayerPrefs.GetString("NomJoueur");
            nomJoueurText.text = "Nom : " + nomJoueurEnregistre;
        }
    }


    void Update()
    {
        // Your existing code...

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Other existing code...

            // UpdateMeilleurScore is the correct method in ScoreManager
            FindObjectOfType<ScoreManager>().UpdateMeilleurScore(GetScoreFinal());

            // Other existing code...
        }
    }
}
