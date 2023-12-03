using UnityEngine;
using UnityEngine.UI;

public class BarreUtilisation : MonoBehaviour
{
    public Slider slider; // R�f�rence au Slider dans l'�diteur Unity
    public GameObject prefabAAppeler; // Le pr�fab � instancier lorsque la barre atteint le seuil actuel

    private int charges = 0;
    private int seuilActuel = 20; // Seuil initial

    void Start()
    {
        slider.value = 0; // Initialiser la barre � 0 au d�marrage
    }

    void Update()
    {
        // Vous pouvez ajouter d'autres fonctionnalit�s ici si n�cessaire
    }

    // Fonction pour augmenter les charges
    public void AugmenterCharges()
    {
        charges++;

        // Mettez � jour la valeur du Slider
        slider.value = charges / (float)seuilActuel;

        // V�rifiez si les charges atteignent le seuil actuel
        if (charges == seuilActuel)
        {
            AppelerPrefab();
        }
    }

    // Fonction pour appeler le pr�fab et d�truire apr�s 3 secondes
    void AppelerPrefab()
    {
        // Informez le SpawnManager que la BarreUtilisation est pr�sente
        FindObjectOfType<SpawnManager>().BarreUtilisationPresente(true);

        // Instancier le pr�fab � la position (0, 0, 0)
        GameObject instance = Instantiate(prefabAAppeler, new Vector3(1, 0, -1), Quaternion.identity);

        // D�truire le pr�fab apr�s 3 secondes
        Destroy(instance, 1.8f);

        // Augmenter le seuil actuel (par exemple, de 5 � chaque r�initialisation)
        seuilActuel += 5;

        // R�initialiser les charges � 0
        charges = 0;
        slider.value = 0;

        // Informez le SpawnManager que la BarreUtilisation n'est plus pr�sente
        FindObjectOfType<SpawnManager>().BarreUtilisationPresente(false);
    }
}
