using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionUiJeux : MonoBehaviour
{
    public TextMeshProUGUI tempsText;
    public TextMeshProUGUI tirText;
    public TextMeshProUGUI ennemiAbattuText;
    public TextMeshProUGUI scoreFinalText;
    public TextMeshProUGUI _txtRestart;
    public GameObject _pausePanel;
    private int tempsDeJeuEnSecondes = 0;
    private int tirs = 0;
    private int ennemisAbattus = 0;
    private bool _pauseOn = false;

    private ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager not found in the scene.");
        }
        ResetScores();
        MiseAJourUI();
    }

    void Update()
    {
        tempsDeJeuEnSecondes = Mathf.RoundToInt(Time.time);
        tempsText.text = "Temps : " + tempsDeJeuEnSecondes;

        MettreAJourScoreFinal();
        SauvegarderScoresTemporaires();
        if (_txtRestart.gameObject.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (_txtRestart.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if ((Input.GetKeyDown(KeyCode.Escape) && !_txtRestart.gameObject.activeSelf) && !_pauseOn)
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
            _pauseOn = true;
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) && !_txtRestart.gameObject.activeSelf) && _pauseOn)
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
            _pauseOn = false;
        }

        if (SceneManager.GetActiveScene().name == "FinDePartie")
        {
            Time.timeScale = 0;
        }
    }

    public void AugmenterTir()
    {
        tirs++;
        tirText.text = "Tir : " + tirs;
    }

    public void AugmenterEnnemiAbattu()
    {
        ennemisAbattus++;
        ennemiAbattuText.text = "Ennemi abattu : " + ennemisAbattus;
    }

    private void MettreAJourScoreFinal()
    {
        int scoreFinal = tempsDeJeuEnSecondes + (10 * ennemisAbattus) - tirs;
        scoreFinalText.text = "" + scoreFinal;

        // Update the score in ScoreManager
        scoreManager.UpdateMeilleurScore(scoreFinal);
    }

    private void MiseAJourUI()
    {
        tempsText.text = "Temps : " + tempsDeJeuEnSecondes;
        tirText.text = "Tir : " + tirs;
        ennemiAbattuText.text = "Ennemi abattu : " + ennemisAbattus;
        MettreAJourScoreFinal();
    }
    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }
    public void SauvegarderScoresTemporaires()
    {
        PlayerPrefs.SetInt("TempsDeJeu", tempsDeJeuEnSecondes);
        PlayerPrefs.SetInt("Tirs", tirs);
        PlayerPrefs.SetInt("EnnemisAbattus", ennemisAbattus);
        PlayerPrefs.SetInt("ScoreFinal", GetScoreFinal());
        PlayerPrefs.Save();
    }
    public void ChangerDeScene(string sceneName)
    {
        SauvegarderScoresTemporaires();
        SceneManager.LoadScene(sceneName);
    }
    public int GetScoreFinal()
    {
        int scoreFinal = tempsDeJeuEnSecondes + ennemisAbattus - tirs;
        return scoreFinal;
    }

    public void ResetScores()
    {
        // Reset all scores and time to 0
        tempsDeJeuEnSecondes = 0;
        tirs = 0;
        ennemisAbattus = 0;

        // Reset the game time to 0
        Time.timeScale = 1;

        // Update UI to reflect the reset values
        MiseAJourUI();
    }
}
