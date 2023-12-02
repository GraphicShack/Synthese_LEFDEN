using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private AudioClip _sonExplosion = default;
    private BarreUtilisation barreUtilisation; // R�f�rence au script BarreUtilisation

    private void Start()
    {
        // R�cup�rer la r�f�rence au script BarreUtilisation dans la sc�ne
        barreUtilisation = FindObjectOfType<BarreUtilisation>();

        // V�rifier si la r�f�rence a �t� trouv�e avant de l'utiliser
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
        // Vous pouvez ajouter d'autres fonctionnalit�s ici si n�cessaire
    }
}
