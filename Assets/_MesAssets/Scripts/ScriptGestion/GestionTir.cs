using System.Collections;
using UnityEngine;

public class GestionTir : MonoBehaviour
{
    [SerializeField] private GameObject laserJoueur;
    [SerializeField] private GameObject tripleLaserJoueur;
    [SerializeField] private float vitesseTirNormale = 0.3f;
    [SerializeField] private float vitesseTirRapide = 0.05f;
    [SerializeField] private GameObject _prefabFire = default;

    private float peutTirer = 0f;
    private bool tripleLaserActif = false;
    private bool tirRapideActive = false;

    private GestionUiJeux gestionUiJeux;
    private BarreUtilisation barreUtilisation;

    void Start()
    {
        gestionUiJeux = FindObjectOfType<GestionUiJeux>();
    }

    void Update()
    {
        TirerLaser();
    }

    private void TirerLaser()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > peutTirer)
        {
            float vitesseTir =vitesseTirNormale;

            GameObject nouveauLaser = Instantiate(laserJoueur, transform.position + new Vector3(2.5f, .7f, 0f), Quaternion.identity);
            gestionUiJeux.AugmenterTir();
            _prefabFire.SetActive(true);
            StartCoroutine(FireCoroutine());
            DetruireLaserAuContact(nouveauLaser);

            peutTirer = Time.time + vitesseTir;
        }
    }

    public void ActiverTripleLaser()
    {
        tripleLaserActif = true;
    }

    public void DesactiverTripleLaser()
    {
        tripleLaserActif = false;
    }

    private void DetruireLaserAuContact(GameObject laser)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(laser.transform.position, 0.2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Ennemi"))
            {
                gestionUiJeux.AugmenterEnnemiAbattu();
                Destroy(laser);
                Destroy(collider.gameObject);
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
        yield return new WaitForSeconds(10.0f);
        tirRapideActive = false;
    }
    private IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(0.35f);
        _prefabFire.SetActive(false);
    }
}
