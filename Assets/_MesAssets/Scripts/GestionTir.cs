using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTir : MonoBehaviour
{
    [SerializeField] private GameObject laserJoueur;  // R�f�rence au laser simple
    [SerializeField] private GameObject tripleLaserJoueur;  // R�f�rence au laser triple
    private float cadenceTir = 0.5f;  // Cadence de tir en secondes
    private float peutTirer = 0f;  // Moment o� le joueur peut tirer
    private bool tripleLaserActif = false;  // Indique si le tir triple est activ�
    [SerializeField] private GameObject _prefabFire = default;
    private bool _FireOn = false;

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
    IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(0.35f);
        _prefabFire.SetActive(false);
    }
    private void TirerLaser()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > peutTirer)
        {
            //AudioSource.PlayClipAtPoint(sonLaser, Camera.main.transform.position, 0.4f);

            if (!tripleLaserActif)
            {
                GameObject nouveauLaser = Instantiate(laserJoueur, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                gestionUiJeux.AugmenterTir();
                _prefabFire.SetActive(true);
                StartCoroutine(FireCoroutine());
                DetruireLaserAuContact(nouveauLaser);
            }
            else
            {
                GameObject nouveauTripleLaser = Instantiate(tripleLaserJoueur, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                DetruireLaserAuContact(nouveauTripleLaser);
            }

            peutTirer = Time.time + cadenceTir;
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
}