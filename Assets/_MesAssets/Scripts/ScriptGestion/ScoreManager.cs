using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int bestScore = 0;
    private string currentPlayerName = "JoueurAnonyme";
    private string bestPlayerName = "JoueurAnonyme";

    void Start()
    {
        // Load the best score and the name of the best player from PlayerPrefs
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        bestPlayerName = PlayerPrefs.GetString("BestPlayerName", "JoueurAnonyme");

        // ... Other existing actions in your Start()
    }

    public void UpdateMeilleurScore(int newScore)
    {
        // Your logic to update the best score (using PlayerPrefs) goes here
        // ...

        // If the new score is higher than the current best score
        if (newScore > bestScore)
        {
            // Set the name of the current player as the best player
            bestPlayerName = currentPlayerName;

            // Save the new best score and the player's name in PlayerPrefs
            PlayerPrefs.SetInt("BestScore", newScore);
            PlayerPrefs.SetString("BestPlayerName", bestPlayerName);
            PlayerPrefs.Save();
        }

        // Then call UpdateMeilleurScoreUI to update the UI
        UpdateMeilleurScoreUI();
    }

    private void UpdateMeilleurScoreUI()
    {
        int meilleurScore = GetMeilleurScore();
        string nomMeilleurJoueur = GetMeilleurNomJoueur();

        // Assuming scoreText is the TextMeshProUGUI component
        if (scoreText != null)
        {
            // Update the Text property of the TextMeshProUGUI component
            scoreText.text = nomMeilleurJoueur + " - " + meilleurScore;
        }
        else
        {
            // Log an error if scoreText is not linked correctly
            Debug.LogError("scoreText is not assigned in the inspector!");
        }
    }

    public int GetMeilleurScore()
    {
        return bestScore;
    }

    public string GetMeilleurNomJoueur()
    {
        return currentPlayerName;
    }

}
