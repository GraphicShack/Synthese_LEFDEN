using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;
    private int[] topScores = new int[5] { 0, 0, 0, 0, 0 };
    private string playerName = "JoueurAnonyme";

    void Start()
    {
        for (int i = 0; i < topScores.Length; i++)
        {
            topScores[i] = PlayerPrefs.GetInt("TopScore_" + i, 0);
        }

        // ... Autres actions de votre Start() existant
    }

    public void UpdateMeilleurScore(int newScore)
    {
        int insertIndex = FindInsertIndex(newScore);

        if (insertIndex != -1)
        {
            InsertScore(insertIndex, newScore);
        }

        // Appelez ensuite UpdateMeilleurScoreUI pour mettre à jour l'interface utilisateur
        UpdateMeilleurScoreUI();
    }

    private void UpdateMeilleurScoreUI()
    {
        int meilleurScore = GetMeilleurScore();
        string nomMeilleurJoueur = GetMeilleurNomJoueur();

        // Vous devriez implémenter votre propre logique pour afficher ces informations
        // Pour chaque TextMeshProUGUI dans scoreTexts, affectez le texte approprié
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = nomMeilleurJoueur + " - " + meilleurScore;
        }
    }

    public int GetMeilleurScore()
    {
        return topScores[0];
    }

    public string GetMeilleurNomJoueur()
    {
        return playerName;
    }

    private int FindInsertIndex(int newScore)
    {
        for (int i = 0; i < topScores.Length; i++)
        {
            if (newScore > topScores[i])
            {
                return i;
            }
        }

        return -1;
    }

    private void InsertScore(int index, int newScore)
    {
        // Insérer le nouveau score à la position spécifiée
        for (int i = topScores.Length - 1; i > index; i--)
        {
            topScores[i] = topScores[i - 1];
        }

        topScores[index] = newScore;

        // Enregistrer le tableau mis à jour dans PlayerPrefs
        for (int i = 0; i < topScores.Length; i++)
        {
            PlayerPrefs.SetInt("TopScore_" + i, topScores[i]);
        }
        PlayerPrefs.Save();
    }
}
