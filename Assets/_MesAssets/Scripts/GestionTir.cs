using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTir : MonoBehaviour
{
    [SerializeField] private GameObject laserJoueur;  // R�f�rence au laser simple
    [SerializeField] private GameObject tripleLaserJoueur;  // R�f�rence au laser triple
    private float peutTirer = 0f;  // Moment o� le joueur peut tirer
    private bool tripleLaserActif = false;  // Indique si le tir triple est activ�
    private bool tirRapideActive = false;  // Indique si la vitesse de tir est actuellement augment�e
    private float vitesseTirNormale = 0.6f;  // Vitesse de tir normale
    private float vitesseTirRapide = 0.0005f;  // Vitesse de tir augment�e

    private GestionUiJeux gestionUiJeux;

    void Start()
    {
        // Trouver le UIManager dans la sc�ne au d�marrage
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

            peutTirer = Time.time + vitesseTir;  // Utilisez la vitesse appropri�e
        }
    }

    // M�thode pour activer le tir triple (� appeler depuis un autre script, par exemple)
    public void ActiverTripleLaser()
    {
        tripleLaserActif = true;
    }

    // M�thode pour d�sactiver le tir triple
    public void DesactiverTripleLaser()
    {
        tripleLaserActif = false;
    }

    // M�thode pour d�truire le laser et l'ennemi au contact
    private void DetruireLaserAuContact(GameObject laser)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(laser.transform.position, 0.2f);  // Ajustez le rayon selon vos besoins

        foreach (Collider2D collider in colliders)
        {
            if (collider.tag == "Ennemi")  // Utilisez le tag appropri� pour l'ennemi
            {
                gestionUiJeux.AugmenterEnnemiAbattu();
                Destroy(laser);
                Destroy(collider.gameObject);
                // Ajoutez ici toute autre logique que vous souhaitez ex�cuter lorsqu'un ennemi est touch� par un laser.
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