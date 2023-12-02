using UnityEngine;
using UnityEngine.UI;

public class BarreUtilisation : MonoBehaviour
{
    public Slider slider; // R�f�rence au Slider dans l'�diteur Unity
    public GameObject prefabAAppeler; // Le pr�fab � instancier lorsque la barre atteint 20 charges

    private int charges = 0;
    public float decreaseInterval = 2f; // Intervalle de diminution en secondes
    public float decreaseAmount = 0.01f; // Montant de diminution par seconde

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
        slider.value = charges / 20f;

        // V�rifiez si les charges atteignent 20
        if (charges == 20)
        {
            AppelerPrefab();
        }
    }

    // Fonction pour diminuer les charges lentement
    public void DiminuerCharges()
    {
        if (charges > 0)
        {
            charges--;

            // Diminuer la valeur de la barre de 0.01
            slider.value = Mathf.Max(0, slider.value - decreaseAmount);
        }
    }

    // Fonction pour appeler le pr�fab et r�initialiser les charges � 0
    void AppelerPrefab()
    {
        // Instancier le pr�fab � la position (0, 0, 0)
        Instantiate(prefabAAppeler, new Vector3(0, 0, -10), Quaternion.identity);

        // R�initialiser les charges � 0
        charges = 0;
        slider.value = 0;
    }
}
