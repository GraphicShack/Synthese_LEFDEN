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
        // Désactiver le panel des instructions au chargement de la scène
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }

        if (mainPanel != null)
        {
            mainPanel.SetActive(true);
        }

    }

    // Méthode appelée lorsqu'on appuie sur le bouton "Jouer"
    public void Jouer()
    {
        SceneManager.LoadScene("JeuxPrincipal"); // Remplacez "NomDeVotreScene" par le nom de la scène que vous souhaitez charger
    }

    // Méthode appelée lorsqu'on appuie sur le bouton "Instructions"
    public void AfficherInstructions()
    {
        // Désactiver le panel actuel
        gameObject.SetActive(true);

        // Activer le panel des instructions
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
            mainPanel.SetActive(false);
        }
    }

    // Méthode appelée lorsqu'on appuie sur le bouton "Quitter"
    public void Quitter()
    {
        // Quitter l'application (seulement en mode standalone, pas en mode éditeur)
        Application.Quit();
    }
}
