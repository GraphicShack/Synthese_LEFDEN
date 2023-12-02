using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    public float intervalleApparition = 4.0f;
    public float tempsApparitionMin = 1.0f;
    public float intervalleDiminutionTempsApparition = 30.0f;
    public float diminutionTempsApparition = 1.0f;

    private int spawnCounter = 0;
    public int spawnInterval = 8;
    public float rarePrefabProbability = 0.1f;

    private bool barreUtilisationPresente = false;

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

            if (!barreUtilisationPresente)
            {
                SpawnEnemy(positionY1);
                SpawnEnemy(positionY2);

                // Vérifie si c'est le moment de spawn le quatrième préfab
                if (spawnCounter % spawnInterval == 0 && Random.value < rarePrefabProbability)
                {
                    float positionY3 = ObtenirYApparitionAleatoire();
                    SpawnEnemy(positionY3);
                }
            }

            spawnCounter++;

            yield return new WaitForSeconds(Mathf.Max(intervalleApparition, tempsApparitionMin));
        }
    }

    void SpawnEnemy(float positionY)
    {
        GameObject nouvelEnnemi = Instantiate(GetRandomEnemyPrefab(), new Vector3(12f, positionY, 0f), Quaternion.Euler(0f, 0f, -90f));
        nouvelEnnemi.AddComponent<CollisionEnnemi>();
    }

    GameObject GetRandomEnemyPrefab()
    {
        if (Random.value < rarePrefabProbability)
        {
            return enemyPrefabs[enemyPrefabs.Count - 1];
        }
        else
        {
            return enemyPrefabs[Random.Range(0, enemyPrefabs.Count - 1)];
        }
    }

    float ObtenirYApparitionAleatoire(float exclusionY = float.NaN)
    {
        float[] positionsYApparition = { -2.5f, 0f, 2.5f };
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

    public void DetruireTousLesPrefabs()
    {
        GameObject[] ennemisEnJeu = GameObject.FindGameObjectsWithTag("Ennemi");

        foreach (GameObject ennemi in ennemisEnJeu)
        {
            Destroy(ennemi);
        }
    }

    public void BarreUtilisationPresente(bool presente)
    {
        barreUtilisationPresente = presente;
        if (presente)
        {
            DetruireTousLesPrefabs();
        }
    }
}
