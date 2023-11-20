using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestionUiJeux : MonoBehaviour
{
    public TextMeshProUGUI tempsText;
    public TextMeshProUGUI tirText;
    public TextMeshProUGUI ennemiAbattuText;
    public TextMeshProUGUI scoreFinalText;
    //public TextMeshProUGUI _txtQuit;
    public TextMeshProUGUI _txtRestart;
    public GameObject _pausePanel;
    private int tempsDeJeuEnSecondes = 0;
    private int tirs = 0;
    private int ennemisAbattus = 0;
    private bool _pauseOn = false;

    void Start()
    {
        MiseAJourUI();
    }

    void Update()
    {
        tempsDeJeuEnSecondes = Mathf.RoundToInt(Time.time);
        tempsText.text = "Temps : " + tempsDeJeuEnSecondes;

        MettreAJourScoreFinal();
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
        int scoreFinal = tempsDeJeuEnSecondes + ennemisAbattus - tirs;
        scoreFinalText.text = "Score Final : " + scoreFinal;
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
}
