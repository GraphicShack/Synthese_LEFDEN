using UnityEngine;
using TMPro;

public class GestionUiFinDePartie : MonoBehaviour
{
    public TextMeshProUGUI tempsText;
    public TextMeshProUGUI tirText;
    public TextMeshProUGUI ennemiAbattuText;
    public TextMeshProUGUI scoreFinalText;
    public TextMeshProUGUI nomJoueurText; // Ajout du TextMeshProUGUI pour le nom du joueur

    void Start()
    {
        // Récupérer le nom du joueur sauvegardé temporairement
        string nomJoueur = PlayerPrefs.GetString("NomJoueur", "JoueurAnonyme");

        // Récupérer les scores sauvegardés temporairement
        int tempsDeJeu = PlayerPrefs.GetInt("TempsDeJeu", 0);
        int tirs = PlayerPrefs.GetInt("Tirs", 0);
        int ennemisAbattus = PlayerPrefs.GetInt("EnnemisAbattus", 0);
        int scoreFinal = PlayerPrefs.GetInt("ScoreFinal", 0);

        // Afficher les scores dans les TextMeshProUGUI
        tempsText.text = "Temps : " + tempsDeJeu;
        tirText.text = "Tir : " + tirs;
        ennemiAbattuText.text = "Ennemi abattu : " + ennemisAbattus;
        scoreFinalText.text = "Score Final : " + scoreFinal;
        nomJoueurText.text = "Nom : " + nomJoueur; // Afficher le nom du joueur

        // Effacer les valeurs sauvegardées
        PlayerPrefs.DeleteKey("NomJoueur");
        PlayerPrefs.DeleteKey("TempsDeJeu");
        PlayerPrefs.DeleteKey("Tirs");
        PlayerPrefs.DeleteKey("EnnemisAbattus");
        PlayerPrefs.DeleteKey("ScoreFinal");
        PlayerPrefs.Save();

        FindObjectOfType<ScoreManager>().UpdateScores();
    }
}
