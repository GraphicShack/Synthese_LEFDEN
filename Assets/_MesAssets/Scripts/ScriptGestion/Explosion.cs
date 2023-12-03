using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip _sonExplosion = default;
    private BarreUtilisation barreUtilisation; // Référence au script BarreUtilisation

    private void Start()
    {
        // Récupérer la référence au script BarreUtilisation dans la scène
        barreUtilisation = FindObjectOfType<BarreUtilisation>();

        // Vérifier si la référence a été trouvée avant de l'utiliser
        if (barreUtilisation != null)
        {
            // Appeler la fonction AugmenterCharges du script BarreUtilisation
            barreUtilisation.AugmenterCharges();
        }

        AudioSource.PlayClipAtPoint(_sonExplosion, Camera.main.transform.position, 0.4f);
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        // Vous pouvez ajouter d'autres fonctionnalités ici si nécessaire
    }
}
