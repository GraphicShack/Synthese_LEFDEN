using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SciptMenuPrincipal : MonoBehaviour
{
    public GameObject instructionPanel;
    public GameObject mainPanel;

    void Start()
    {
        // D�sactiver le panel des instructions au chargement de la sc�ne
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }

        if (mainPanel != null)
        {
            mainPanel.SetActive(true);
        }

    }

    // M�thode appel�e lorsqu'on appuie sur le bouton "Jouer"
    public void Jouer()
    {
        SceneManager.LoadScene("JeuxPrincipal"); // Remplacez "NomDeVotreScene" par le nom de la sc�ne que vous souhaitez charger
    }

    // M�thode appel�e lorsqu'on appuie sur le bouton "Instructions"
    public void AfficherInstructions()
    {
        // D�sactiver le panel actuel
        gameObject.SetActive(true);

        // Activer le panel des instructions
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
            mainPanel.SetActive(false);
        }
    }

    // M�thode appel�e lorsqu'on appuie sur le bouton "Quitter"
    public void Quitter()
    {
        // Quitter l'application (seulement en mode standalone, pas en mode �diteur)
        Application.Quit();
    }
}
