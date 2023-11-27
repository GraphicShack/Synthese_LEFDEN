using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Tableau de TextMeshProUGUI pour afficher les scores
    private int currentScore = 0; // Score actuel
    private GestionUiJeux gestionUiJeux; // R�f�rence � GestionUiJeux

    void Start()
    {
        // Trouver l'objet GestionUiJeux dans la sc�ne
        gestionUiJeux = FindObjectOfType<GestionUiJeux>();

        // Mettre � jour l'affichage des scores au d�marrage
        UpdateScoreUI();
    }

    // Fonction pour mettre � jour les scores et les afficher
    public void UpdateScores()
    {
        // R�cup�rer le score final affich� dans GestionUiJeux
        currentScore = gestionUiJeux.GetScoreFinal();

        // R�cup�rer le tableau global de scores
        int[] topScores = GlobalScoreManager.topScores;

        // V�rifier si le nouveau score est plus grand que les scores existants
        bool scoreInserted = false;
        for (int i = 0; i < topScores.Length; i++)
        {
            if (currentScore > topScores[i])
            {
                // Ins�rer le nouveau score � la position i
                InsertScore(i);
                scoreInserted = true;
                break;
            }
        }

        // Mettre � jour l'affichage des scores apr�s insertion
        if (scoreInserted)
        {
            UpdateScoreUI();
        }
    }

    // Fonction pour ins�rer un nouveau score � la position donn�e
    private void InsertScore(int index)
    {
        // D�placer les scores vers le bas pour faire de la place au nouveau score
        for (int i = GlobalScoreManager.topScores.Length - 1; i > index; i--)
        {
            GlobalScoreManager.topScores[i] = GlobalScoreManager.topScores[i - 1];
        }

        // Ins�rer le nouveau score � la position sp�cifi�e
        GlobalScoreManager.topScores[index] = currentScore;
    }

    // Fonction pour mettre � jour l'affichage des scores dans les TextMeshProUGUI
    private void UpdateScoreUI()
    {
        for (int i = 0; i < GlobalScoreManager.topScores.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + " - " + GlobalScoreManager.topScores[i].ToString();
        }
    }
}
