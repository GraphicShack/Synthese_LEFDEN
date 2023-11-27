using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts; // Tableau de TextMeshProUGUI pour afficher les scores
    private int[] topScores = new int[5] { 0, 0, 0, 0, 0 }; // Tableau pour stocker les meilleurs scores, avec 5 fois le chiffre 0
    private int currentScore = 0; // Score actuel
    private GestionUiJeux gestionUiJeux; // R�f�rence � GestionUiJeux

    void Start()
    {
        // Initialisation des scores � 0 au d�but du jeu
        for (int i = 0; i < topScores.Length; i++)
        {
            topScores[i] = PlayerPrefs.GetInt("TopScore_" + i, 0);
        }

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

        // Trouver l'index o� le nouveau score doit �tre ins�r�
        int insertIndex = FindInsertIndex(currentScore);

        // Ins�rer le nouveau score � la position sp�cifi�e
        InsertScore(insertIndex);

        // Mettre � jour l'affichage des scores apr�s insertion
        UpdateScoreUI();
    }

    // Fonction pour trouver l'index o� le nouveau score doit �tre ins�r�
    private int FindInsertIndex(int newScore)
    {
        for (int i = 0; i < topScores.Length; i++)
        {
            if (newScore > topScores[i])
            {
                return i;
            }
        }

        return -1; // Retourner -1 si le score n'est pas assez �lev� pour �tre parmi les meilleurs
    }

    // Fonction pour ins�rer un nouveau score � la position donn�e
    private void InsertScore(int index)
    {
        // S'assurer que l'index est valide
        if (index < 0 || index >= topScores.Length)
        {
            return;
        }

        // Si le nouveau score est plus bas que le dernier score, ne pas l'ins�rer
        if (index == topScores.Length - 1 && currentScore <= topScores[index])
        {
            return;
        }

        // D�caler les scores vers le bas � partir de l'index sp�cifi�
        for (int i = topScores.Length - 1; i > index; i--)
        {
            topScores[i] = topScores[i - 1];
        }

        // Ins�rer le nouveau score � la position sp�cifi�e
        topScores[index] = currentScore;

        // Enregistrer le tableau mis � jour dans PlayerPrefs
        for (int i = 0; i < topScores.Length; i++)
        {
            PlayerPrefs.SetInt("TopScore_" + i, topScores[i]);
        }
        PlayerPrefs.Save();
    }

    // Fonction pour mettre � jour l'affichage des scores dans les TextMeshProUGUI
    private void UpdateScoreUI()
    {
        // V�rifier que le tableau de scores et les TextMeshProUGUI sont valides
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
