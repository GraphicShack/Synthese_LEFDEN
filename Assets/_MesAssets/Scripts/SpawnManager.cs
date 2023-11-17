using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;  // Référence au prefab de l'ennemi
    public float intervalleApparition = 4.0f;  // Intervalle de temps pour l'apparition des ennemis
    public float tempsApparitionMin = 1.0f;   // Temps d'apparition minimum autorisé
    public float intervalleDiminutionTempsApparition = 30.0f;  // Intervalle pour diminuer le temps d'apparition
    public float diminutionTempsApparition = 1.0f;  // Montant de diminution du temps d'apparition

    void Start()
    {
        StartCoroutine(CoroutineApparitionEnnemis());
        StartCoroutine(CoroutineDiminutionTempsApparition());
    }

    IEnumerator CoroutineApparitionEnnemis()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Mathf.Max(intervalleApparition, tempsApparitionMin));
        }
    }

    void SpawnEnemy()
    {
        float positionY = ObtenirYApparitionAleatoire();
        GameObject nouvelEnnemi = Instantiate(enemyPrefab, new Vector3(12f, positionY, 0f), Quaternion.Euler(0f, 0f, -90f));
        // Ajouter le script de gestion des collisions à l'ennemi
        nouvelEnnemi.AddComponent<CollisionEnnemi>();
    }

    float ObtenirYApparitionAleatoire()
    {
        float[] positionsYApparition = { -2.5f, 0f, 2.5f };
        return positionsYApparition[Random.Range(0, positionsYApparition.Length)];
    }

    IEnumerator CoroutineDiminutionTempsApparition()
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalleDiminutionTempsApparition);
            intervalleApparition = Mathf.Max(intervalleApparition - diminutionTempsApparition, tempsApparitionMin);
        }
    }
}
