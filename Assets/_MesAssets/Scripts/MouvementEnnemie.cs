using UnityEngine;

public class MouvementEnnemie : MonoBehaviour
{
    private float vitesseMin = 3.0f;
    private float vitesseMax = 4.0f;
    private float vitesseActuelle;
    public float stopXCoordinate = -8.0f;

    private GestionJeux gestionJeux;

    private void Start()
    {
        vitesseActuelle = Random.Range(vitesseMin, vitesseMax);
        InvokeRepeating("AugmenterVitesse", 20.0f, 20.0f);

        // Trouver l'objet GestionJeux par son nom
        gestionJeux = GameObject.Find("GestionJeux").GetComponent<GestionJeux>();

        if (gestionJeux == null)
        {
            Debug.LogError("L'objet GestionJeux avec le nom 'GestionJeux' n'a pas été trouvé ou le composant GestionJeux est manquant.");
        }
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
            if (gestionJeux != null)
            {
                gestionJeux.TakeDamage();
            }
        }
    }

    void AugmenterVitesse()
    {
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
