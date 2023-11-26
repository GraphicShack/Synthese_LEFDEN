using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;  // Liste des prefabs d'ennemis
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
            float positionY1 = ObtenirYApparitionAleatoire();
            float positionY2 = ObtenirYApparitionAleatoire(positionY1);

            SpawnEnemy(positionY1);
            SpawnEnemy(positionY2);

            yield return new WaitForSeconds(Mathf.Max(intervalleApparition, tempsApparitionMin));
        }
    }

    void SpawnEnemy(float positionY)
    {
        // Choisi aléatoirement un prefab d'ennemi
        GameObject nouvelEnnemi = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], new Vector3(12f, positionY, 0f), Quaternion.Euler(0f, 0f, -90f));
        // Ajoute le script de gestion des collisions à l'ennemi
        nouvelEnnemi.AddComponent<CollisionEnnemi>();
    }

    float ObtenirYApparitionAleatoire(float exclusionY = float.NaN)
    {
        float[] positionsYApparition = { -2.5f, 0f, 2.5f };

        // Retire la position d'exclusion du tableau
        List<float> positionsDisponibles = new List<float>(positionsYApparition);
        positionsDisponibles.Remove(exclusionY);

        return positionsDisponibles[Random.Range(0, positionsDisponibles.Count)];
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
