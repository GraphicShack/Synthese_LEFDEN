using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Tableau de TextMeshProUGUI pour afficher les scores
    private int[] scores = new int[5]; // Tableau pour stocker les scores
    private int currentScore = 0; // Score actuel

    void Start()
    {
        // Initialisation des scores � 0 au d�but du jeu
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = 0;
        }

        // Mettre � jour l'affichage des scores au d�marrage
        UpdateScoreUI();
    }

    // Fonction pour mettre � jour les scores et les afficher
    public void UpdateScores(int newScore)
    {
        currentScore = newScore;

        // V�rifier si le nouveau score est plus grand que les scores existants
        bool scoreInserted = false;
        for (int i = 0; i < scores.Length; i++)
        {
            if (currentScore > scores[i])
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
        for (int i = scores.Length - 1; i > index; i--)
        {
            scores[i] = scores[i - 1];
        }

        // Ins�rer le nouveau score � la position sp�cifi�e
        scores[index] = currentScore;
    }

    // Fonction pour mettre � jour l'affichage des scores dans les TextMeshProUGUI
    private void UpdateScoreUI()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + " - " + scores[i].ToString();
        }
    }
}