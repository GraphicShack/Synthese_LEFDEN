using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionUiFinDePartie : MonoBehaviour
{
    public TextMeshProUGUI tempsText;
    public TextMeshProUGUI tirText;
    public TextMeshProUGUI ennemiAbattuText;
    public TextMeshProUGUI scoreFinalText;

    void Start()
    {
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

        // Effacer les valeurs sauvegardées
        PlayerPrefs.DeleteKey("TempsDeJeu");
        PlayerPrefs.DeleteKey("Tirs");
        PlayerPrefs.DeleteKey("EnnemisAbattus");
        PlayerPrefs.DeleteKey("ScoreFinal");
        PlayerPrefs.Save();

        FindObjectOfType<ScoreManager>().UpdateScores();
    }
}