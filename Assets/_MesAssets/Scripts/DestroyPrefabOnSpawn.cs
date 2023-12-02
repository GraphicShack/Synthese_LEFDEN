using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabOnSpawn : MonoBehaviour
{
    public float tempsAvantDestruction = 3f;

    void Start()
    {
        // Détruire le préfab après un certain temps
        StartCoroutine(DetruireApresDelai());
    }

    IEnumerator DetruireApresDelai()
    {
        yield return new WaitForSeconds(tempsAvantDestruction);
        // Appeler la fonction de destruction dans le SpawnManager
        FindObjectOfType<SpawnManager>().DetruireTousLesPrefabs();
        // Détruire le préfab actuel
        Destroy(gameObject);
    }
}
