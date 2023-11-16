using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SciptMenuPrincipal : MonoBehaviour
{
    public GameObject instructionPanel;

    void Start()
    {
        // Désactiver le panel des instructions au chargement de la scène
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }
    }

    // Méthode appelée lorsqu'on appuie sur le bouton "Jouer"
    public void Jouer()
    {
        SceneManager.LoadScene("NomDeVotreScene"); // Remplacez "NomDeVotreScene" par le nom de la scène que vous souhaitez charger
    }

    // Méthode appelée lorsqu'on appuie sur le bouton "Instructions"
    public void AfficherInstructions()
    {
        // Désactiver le panel actuel
        gameObject.SetActive(false);

        // Activer le panel des instructions
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }
    }

    // Méthode appelée lorsqu'on appuie sur le bouton "Quitter"
    public void Quitter()
    {
        // Quitter l'application (seulement en mode standalone, pas en mode éditeur)
        Application.Quit();
    }
}
