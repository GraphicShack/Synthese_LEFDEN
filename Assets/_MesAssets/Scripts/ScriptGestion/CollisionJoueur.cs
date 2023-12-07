using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionJoueur : MonoBehaviour
{
    private GestionJeux gestionJeux;
    // Start is called before the first frame update
    void Start()
    {
        gestionJeux = GameObject.FindObjectOfType<GestionJeux>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Ennemi")
        {
            Destroy(other.gameObject);  // Destroy the Taco
            gestionJeux.TakeDamage();
        }
    }
}
