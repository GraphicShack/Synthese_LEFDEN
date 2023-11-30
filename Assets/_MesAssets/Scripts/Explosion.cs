using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _vitesseExplosion = 4f;
    [SerializeField] private AudioClip _sonExplosion = default;
    private GestionUiJeux gestionUiJeux;
    private void Start()
    {
        gestionUiJeux = FindObjectOfType<GestionUiJeux>();

        if (gestionUiJeux != null)
        {
            AudioSource.PlayClipAtPoint(_sonExplosion, Camera.main.transform.position, 0.4f);
            Destroy(gameObject, 4f);
            gestionUiJeux.AugmenterEnnemiAbattu();
        }
        else
        {
            Debug.LogError("GestionUiJeux not found. Make sure it exists in the scene.");
        }
    }





}
