using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementEnnemie : MonoBehaviour
{
    private float vitesseMin = 3.0f;  // Vitesse minimale initiale de l'ennemi
    private float vitesseMax = 4.0f;  // Vitesse maximale initiale de l'ennemi
    private float vitesseActuelle;     // Vitesse actuelle de l'ennemi
    public float stopXCoordinate = -8.0f;  // Coordonnée X à laquelle l'ennemi doit être détruit

    void Start()
    {
        // Initialiser la vitesse avec une valeur aléatoire entre vitesseMin et vitesseMax au démarrage
        vitesseActuelle = Random.Range(vitesseMin, vitesseMax);
        // Appeler la méthode d'augmentation de la vitesse toutes les 20 secondes
        InvokeRepeating("AugmenterVitesse", 20.0f, 20.0f);
    }

    void Update()
    {
        DeplacementDroiteAGauche();
    }

    void DeplacementDroiteAGauche()
    {
        float deplacement = vitesseActuelle * Time.deltaTime;
        transform.Translate(Vector3.down * deplacement);

        if (transform.position.x <= stopXCoordinate)
        {
            Destroy(gameObject);
        }
    }

    void AugmenterVitesse()
    {
        // Ajouter 0.5 à la vitesse actuelle, en s'assurant qu'elle ne dépasse pas vitesseMax
        vitesseActuelle = Mathf.Min(vitesseActuelle + 0.5f, 7.0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Missile")
        {
            Debug.Log("A");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
