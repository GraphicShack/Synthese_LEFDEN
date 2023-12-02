using UnityEngine;
using UnityEngine.UI;

public class BarreUtilisation : MonoBehaviour
{
    public Slider slider; // Référence au Slider dans l'éditeur Unity
    public GameObject prefabAAppeler; // Le préfab à instancier lorsque la barre atteint le seuil actuel

    private int charges = 0;
    private int seuilActuel = 20; // Seuil initial

    void Start()
    {
        slider.value = 0; // Initialiser la barre à 0 au démarrage
    }

    void Update()
    {
        // Vous pouvez ajouter d'autres fonctionnalités ici si nécessaire
    }

    // Fonction pour augmenter les charges
    public void AugmenterCharges()
    {
        charges++;

        // Mettez à jour la valeur du Slider
        slider.value = charges / (float)seuilActuel;

        // Vérifiez si les charges atteignent le seuil actuel
        if (charges == seuilActuel)
        {
            AppelerPrefab();
        }
    }

    // Fonction pour appeler le préfab et détruire après 3 secondes
    void AppelerPrefab()
    {
        // Informez le SpawnManager que la BarreUtilisation est présente
        FindObjectOfType<SpawnManager>().BarreUtilisationPresente(true);

        // Instancier le préfab à la position (0, 0, 0)
        GameObject instance = Instantiate(prefabAAppeler, new Vector3(1, 0, -1), Quaternion.identity);

        // Détruire le préfab après 3 secondes
        Destroy(instance, 1.8f);

        // Augmenter le seuil actuel (par exemple, de 5 à chaque réinitialisation)
        seuilActuel += 5;

        // Réinitialiser les charges à 0
        charges = 0;
        slider.value = 0;

        // Informez le SpawnManager que la BarreUtilisation n'est plus présente
        FindObjectOfType<SpawnManager>().BarreUtilisationPresente(false);
    }
}
