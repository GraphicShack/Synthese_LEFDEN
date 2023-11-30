using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _vitesseExplosion = 2f;
    [SerializeField] private AudioClip _sonExplosion = default;
    
    private void Start()
    {
        AudioSource.PlayClipAtPoint(_sonExplosion, Camera.main.transform.position, 0.4f);
        Destroy(gameObject, 1f);
        
    }

    private void Update()
    {
       
    }


}
