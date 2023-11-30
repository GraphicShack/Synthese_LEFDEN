using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTir : MonoBehaviour
{
    [SerializeField] private GameObject laserJoueur;  // Référence au laser simple
    [SerializeField] private GameObject tripleLaserJoueur;  // Référence au laser triple
    private float peutTirer = 0f;  // Moment où le joueur peut tirer
    private bool tripleLaserActif = false;  // Indique si le tir triple est activé
    private bool tirRapideActive = false;  // Indique si la vitesse de tir est actuellement augmentée
    private float vitesseTirNormale = 0.6f;  // Vitesse de tir normale
    private float vitesseTirRapide = 0.0005f;  // Vitesse de tir augmentée

    private GestionUiJeux gestionUiJeux;

    void Start()
    {
        // Trouver le UIManager dans la scène au démarrage
        gestionUiJeux = GameObject.FindObjectOfType<GestionUiJeux>();
    }

    void Update()
    {
        TirerLaser();
    }

    private void TirerLaser()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > peutTirer)
        {
            float vitesseTir = tirRapideActive ? vitesseTirRapide : vitesseTirNormale;
            // AudioSource.PlayClipAtPoint(sonLaser, Camera.main.transform.position, 0.4f);

            if (!tripleLaserActif)
            {
                GameObject nouveauLaser = Instantiate(laserJoueur, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                gestionUiJeux.AugmenterTir();
                DetruireLaserAuContact(nouveauLaser);
            }
            else
            {
                GameObject nouveauTripleLaser = Instantiate(tripleLaserJoueur, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                DetruireLaserAuContact(nouveauTripleLaser);
            }

            peutTirer = Time.time + vitesseTir;  // Utilisez la vitesse appropriée
        }
    }

    // Méthode pour activer le tir triple (à appeler depuis un autre script, par exemple)
    public void ActiverTripleLaser()
    {
        tripleLaserActif = true;
    }

    // Méthode pour désactiver le tir triple
    public void DesactiverTripleLaser()
    {
        tripleLaserActif = false;
    }

    // Méthode pour détruire le laser et l'ennemi au contact
    private void DetruireLaserAuContact(GameObject laser)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(laser.transform.position, 0.2f);  // Ajustez le rayon selon vos besoins

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Ennemi")  // Utilisez le tag approprié pour l'ennemi
            {
                gestionUiJeux.AugmenterEnnemiAbattu();
                Destroy(laser);
                Destroy(collider.gameObject);
                // Ajoutez ici toute autre logique que vous souhaitez exécuter lorsqu'un ennemi est touché par un laser.
            }
        }
    }

    public void ActiverTirRapide()
    {
        if (!tirRapideActive)
        {
            StartCoroutine(TirRapideCoroutine());
        }
    }
    private IEnumerator TirRapideCoroutine()
    {
        tirRapideActive = true;
        yield return new WaitForSeconds(10.0f);  // Attendre pendant 10 secondes
        tirRapideActive = false;
    }
}