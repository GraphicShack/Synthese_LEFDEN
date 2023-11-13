using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemie : MonoBehaviour
{
    public float minSpeed = 1.0f;   // Vitesse minimale de déplacement de l'ennemi
    public float maxInitialSpeed = 3.0f;   // Vitesse initiale maximale de déplacement de l'ennemi
    public float speedIncreaseInterval = 30.0f;  // Intervalle d'augmentation de la vitesse en secondes
    public float speedIncreaseAmount = 0.5f;  // Montant d'augmentation de la vitesse
    public float stopXCoordinate = -7.71f;  // Coordonnée X à laquelle l'ennemi doit s'arrêter

    private float currentMaxSpeed;  // Vitesse maximale actuelle de l'ennemi

    void Start()
    {
        // Initialiser la vitesse avec une valeur aléatoire entre minSpeed et maxInitialSpeed au démarrage
        currentMaxSpeed = Random.Range(minSpeed, maxInitialSpeed);

        // Appeler la méthode d'augmentation de la vitesse toutes les speedIncreaseInterval secondes
        InvokeRepeating("IncreaseSpeed", speedIncreaseInterval, speedIncreaseInterval);
    }

    void Update()
    {
        // Déplacement de l'ennemi vers la gauche
        MoveLeft();
    }

    void MoveLeft()
    {
        // Si l'ennemi a atteint ou dépassé la coordonnée X d'arrêt, arrêter le mouvement
        if (transform.position.x <= stopXCoordinate)
        {
            return;
        }

        // Calcul du déplacement en fonction de la vitesse et du temps
        float movement = currentMaxSpeed * Time.deltaTime;

        // Appliquer le déplacement à la position de l'ennemi
        transform.Translate(Vector3.left * movement);
    }

    void IncreaseSpeed()
    {
        // Augmenter la vitesse maximale
        currentMaxSpeed += speedIncreaseAmount;
    }
}
