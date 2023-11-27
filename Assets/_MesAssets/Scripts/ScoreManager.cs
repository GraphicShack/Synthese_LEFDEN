using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Tableau de TextMeshProUGUI pour afficher les scores
    private int currentScore = 0; // Score actuel
    private GestionUiJeux gestionUiJeux; // Référence à GestionUiJeux

    void Start()
    {
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

        // Récupérer le tableau global de scores
        int[] topScores = GlobalScoreManager.topScores;

        // Vérifier si le nouveau score est plus grand que les scores existants
        bool scoreInserted = false;
        for (int i = 0; i < topScores.Length; i++)
        {
            if (currentScore > topScores[i])
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
        for (int i = GlobalScoreManager.topScores.Length - 1; i > index; i--)
        {
            GlobalScoreManager.topScores[i] = GlobalScoreManager.topScores[i - 1];
        }

        // Insérer le nouveau score à la position spécifiée
        GlobalScoreManager.topScores[index] = currentScore;
    }

    // Fonction pour mettre à jour l'affichage des scores dans les TextMeshProUGUI
    private void UpdateScoreUI()
    {
        for (int i = 0; i < GlobalScoreManager.topScores.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + " - " + GlobalScoreManager.topScores[i].ToString();
        }
    }
}
