using UnityEngine;
using TMPro;

public class GestionUiJeux : MonoBehaviour
{
    public TextMeshProUGUI tempsText;
    public TextMeshProUGUI tirText;
    public TextMeshProUGUI ennemiAbattuText;
    public TextMeshProUGUI scoreFinalText;

    private int tempsDeJeuEnSecondes = 0;
    private int tirs = 0;
    private int ennemisAbattus = 0;

    void Start()
    {
        MiseAJourUI();
    }

    void Update()
    {
        tempsDeJeuEnSecondes = Mathf.RoundToInt(Time.time);
        tempsText.text = "Temps : " + tempsDeJeuEnSecondes;

        MettreAJourScoreFinal();
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
}
