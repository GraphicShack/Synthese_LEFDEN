using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnnemi : MonoBehaviour
{

    private GestionUiJeux gestionUiJeux;

    void Start()
    {
        // Trouver le UIManager dans la scène au démarrage
        gestionUiJeux = GameObject.FindObjectOfType<GestionUiJeux>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered with {other.gameObject.name}");

        if (other.CompareTag("Missile"))
        {
            gestionUiJeux.AugmenterEnnemiAbattu();
            Debug.Log("Missile detected!");
            Destroy(other.gameObject);  // Destroy the missile
            Destroy(gameObject);  // Destroy the enemy
        }
    }
}
