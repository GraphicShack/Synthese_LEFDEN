using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Tableau de TextMeshProUGUI pour afficher les scores
    private int[] topScores = new int[5] { 0, 0, 0, 0, 0 }; // Tableau pour stocker les meilleurs scores, avec 5 fois le chiffre 0
    private int currentScore = 0; // Score actuel
    private GestionUiJeux gestionUiJeux; // Référence à GestionUiJeux

    void Start()
    {
        // Initialisation des scores à 0 au début du jeu
        for (int i = 0; i < topScores.Length; i++)
        {
            topScores[i] = PlayerPrefs.GetInt("TopScore_" + i, 0);
        }

        // Trouver l'objet GestionUiJeux dans la scène
        gestionUiJeux = FindObjectOfType<GestionUiJeux>();

        // Mettre à jour l'affichage des scores au démarrage
        UpdateScoreUI();
    }

    // Fonction pour mettre à jour les scores et les afficher
    public void UpdateScores()
    {
        // Récupérer le score final affiché dans GestionUiJeux
        currentScore = gestionUiJeux.GetScoreFinal();

        // Trouver l'index où le nouveau score doit être inséré
        int insertIndex = FindInsertIndex(currentScore);

        // Insérer le nouveau score à la position spécifiée
        InsertScore(insertIndex);

        // Mettre à jour l'affichage des scores après insertion
        UpdateScoreUI();
    }

    // Fonction pour trouver l'index où le nouveau score doit être inséré
    private int FindInsertIndex(int newScore)
    {
        for (int i = 0; i < topScores.Length; i++)
        {
            if (newScore > topScores[i])
            {
                return i;
            }
        }

        return -1; // Retourner -1 si le score n'est pas assez élevé pour être parmi les meilleurs
    }

    // Fonction pour insérer un nouveau score à la position donnée
    private void InsertScore(int index)
    {
        // S'assurer que l'index est valide
        if (index < 0 || index >= topScores.Length)
        {
            return;
        }

        // Si le nouveau score est plus bas que le dernier score, ne pas l'insérer
        if (index == topScores.Length - 1 && currentScore <= topScores[index])
        {
            return;
        }

        // Décaler les scores vers le bas à partir de l'index spécifié
        for (int i = topScores.Length - 1; i > index; i--)
        {
            topScores[i] = topScores[i - 1];
        }

        // Insérer le nouveau score à la position spécifiée
        topScores[index] = currentScore;

        // Enregistrer le tableau mis à jour dans PlayerPrefs
        for (int i = 0; i < topScores.Length; i++)
        {
            PlayerPrefs.SetInt("TopScore_" + i, topScores[i]);
        }
        PlayerPrefs.Save();
    }

    // Fonction pour mettre à jour l'affichage des scores dans les TextMeshProUGUI
    private void UpdateScoreUI()
    {
        // Vérifier que le tableau de scores et les TextMeshProUGUI sont valides
        if (scoreTexts != null && scoreTexts.Length == topScores.Length)
        {
            for (int i = 0; i < topScores.Length; i++)
            {
                scoreTexts[i].text = (i + 1) + " - " + topScores[i].ToString();
            }
        }
        else
        {
            Debug.LogError("ScoreTexts array is not properly set up or has an incorrect length.");
        }
    }
}
