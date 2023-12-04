using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionTirEnnemi : MonoBehaviour
{
    public float projectileChance = 0.3f;
    [SerializeField] private GameObject TacoEnnemi;
    private void Start()
    {
        // Simulate the enemy's behavior for multiple rounds (for demonstration purposes)
        for (int roundNum = 1; roundNum <= 5; roundNum++)
        {
            bool launch = LaunchProjectile();

            if (launch)
            {
                GameObject nouveauTaco = Instantiate(TacoEnnemi, transform.position, Quaternion.identity);
                DetruireTacoAuContact(nouveauTaco);
            }
        }
    }
    private void DetruireTacoAuContact(GameObject TacoEnnemi)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(TacoEnnemi.transform.position, 0.2f);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                Destroy(TacoEnnemi);
            }
        }
    }

    private bool LaunchProjectile()
    {
        // Generate a random number between 0 and 1
        float randomNumber = Random.Range(0f, 2f);

        // Check if the random number is less than or equal to the projectile chance
        return randomNumber <= projectileChance;
    }
}

