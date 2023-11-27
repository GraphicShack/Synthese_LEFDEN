using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEnnemi : MonoBehaviour
{
    [SerializeField] private GameObject _prefabExplosion = default;
    private GestionUiJeux gestionUiJeux;

    void Start()
    {
        // Trouver le UIManager dans la scène au démarrage
        gestionUiJeux = GameObject.FindObjectOfType<GestionUiJeux>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered with {other.gameObject.name}");

        if (other.tag == "Missile")
        {
            Debug.Log("Missile detected!");
            Instantiate(_prefabExplosion, transform.position, Quaternion.identity);
            Destroy(other.gameObject);  // Destroy the missile
            Destroy(gameObject);  // Destroy the enemy
            gestionUiJeux.AugmenterEnnemiAbattu();
        }
    }
}
