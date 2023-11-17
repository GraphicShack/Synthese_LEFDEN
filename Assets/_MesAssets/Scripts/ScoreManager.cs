using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Tableau de TextMeshProUGUI pour afficher les scores
    private int[] scores = new int[5]; // Tableau pour stocker les scores
    private int currentScore = 0; // Score actuel

    void Start()
    {
        // Initialisation des scores à 0 au début du jeu
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }

        // Mettre à jour l'affichage des scores au démarrage
        UpdateScoreUI();
    }

    // Fonction pour mettre à jour les scores et les afficher
    public void UpdateScores(int newScore)
    {
        currentScore = newScore;

        // Vérifier si le nouveau score est plus grand que les scores existants
        bool scoreInserted = false;
        for (int i = 0; i < scores.Length; i++)
        {
            if (currentScore > scores[i])
            {
                // Insérer le nouveau score à la position i
                InsertScore(i);
                scoreInserted = true;
                break;
            }
        }

        // Mettre à jour l'affichage des scores après insertion
        if (scoreInserted)
        {
            UpdateScoreUI();
        }
    }

    // Fonction pour insérer un nouveau score à la position donnée
    private void InsertScore(int index)
    {
        // Déplacer les scores vers le bas pour faire de la place au nouveau score
        for (int i = scores.Length - 1; i > index; i--)
        {
            scores[i] = scores[i - 1];
        }

        // Insérer le nouveau score à la position spécifiée
        scores[index] = currentScore;
    }

    // Fonction pour mettre à jour l'affichage des scores dans les TextMeshProUGUI
    private void UpdateScoreUI()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + " - " + scores[i].ToString();
        }
    }
}