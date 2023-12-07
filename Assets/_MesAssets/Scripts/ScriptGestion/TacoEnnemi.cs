using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TacoEnnemi : MonoBehaviour
{
    [SerializeField] private float _vitesseTaco = 6.5f;
    public float tempsAvantDestruction = 3.5f;
    private GestionJeux gestionJeux;

    // Start is called before the first frame update
    void Start()
    {
        // Détruire le préfab après un certain temps
        StartCoroutine(DetruireTacoApresDelai());
        gestionJeux = GameObject.FindObjectOfType<GestionJeux>();
    }
    private void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * _vitesseTaco);

    }
    IEnumerator DetruireTacoApresDelai()
    {
        yield return new WaitForSeconds(tempsAvantDestruction);
        // Appeler la fonction de destruction dans le SpawnManager
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Destroy(this.gameObject);  // Destroy the Taco
            gestionJeux.TakeDamage();
        }
    }
}
