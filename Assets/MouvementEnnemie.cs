using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemie : MonoBehaviour
{
    public float minSpeed = 1.0f;   // Vitesse minimale de d�placement de l'ennemi
    public float maxInitialSpeed = 3.0f;   // Vitesse initiale maximale de d�placement de l'ennemi
    public float speedIncreaseInterval = 30.0f;  // Intervalle d'augmentation de la vitesse en secondes
    public float speedIncreaseAmount = 0.5f;  // Montant d'augmentation de la vitesse

    private float currentMaxSpeed;  // Vitesse maximale actuelle de l'ennemi

    void Start()
    {
        // Initialiser la vitesse avec une valeur al�atoire entre minSpeed et maxInitialSpeed au d�marrage
        currentMaxSpeed = Random.Range(minSpeed, maxInitialSpeed);

        // Appeler la m�thode d'augmentation de la vitesse toutes les speedIncreaseInterval secondes
        InvokeRepeating("IncreaseSpeed", speedIncreaseInterval, speedIncreaseInterval);
    }

    void Update()
    {
        // D�placement de l'ennemi vers la gauche
        MoveLeft();
    }

    void MoveLeft()
    {
        // Calcul du d�placement en fonction de la vitesse et du temps
        float movement = currentMaxSpeed * Time.deltaTime;

        // Appliquer le d�placement � la position de l'ennemi
        transform.Translate(Vector3.left * movement);
    }

    void IncreaseSpeed()
    {
        // Augmenter la vitesse maximale
        currentMaxSpeed += speedIncreaseAmount;
    }
}
