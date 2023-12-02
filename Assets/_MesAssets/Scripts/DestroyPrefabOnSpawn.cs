using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabOnSpawn : MonoBehaviour
{
    public float tempsAvantDestruction = 3f;

    void Start()
    {
        // D�truire le pr�fab apr�s un certain temps
        StartCoroutine(DetruireApresDelai());
    }

    IEnumerator DetruireApresDelai()
    {
        yield return new WaitForSeconds(tempsAvantDestruction);
        // Appeler la fonction de destruction dans le SpawnManager
        FindObjectOfType<SpawnManager>().DetruireTousLesPrefabs();
        // D�truire le pr�fab actuel
        Destroy(gameObject);
    }
}
