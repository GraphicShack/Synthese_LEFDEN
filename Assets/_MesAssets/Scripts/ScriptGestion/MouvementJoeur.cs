using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementJoeur : MonoBehaviour
{
    public float[] yPositions = { -2f, 0f, 2f };  // Les positions Y possibles
    private int currentIndex = 1;  // L'indice de la position Y actuelle

    void Update()
    {
        // Gestion de la navigation avec les touches haut et bas
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Déplacer vers la position Y suivante
            ChangeYPosition(-1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Déplacer vers la position Y précédente
            ChangeYPosition(1);
        }
    }

    void ChangeYPosition(int direction)
    {
        // Changer l'indice de la position Y en fonction de la direction
        currentIndex = (currentIndex + direction + yPositions.Length) % yPositions.Length;

        // Déplacer le joueur vers la nouvelle position Y
        SetYPosition(yPositions[currentIndex]);
    }

    public void SetYPosition(float newY)
    {
        // Mettre à jour la position Y du joueur
        Vector3 newPosition = transform.position;
        newPosition.y = newY;
        transform.position = newPosition;
    }
}