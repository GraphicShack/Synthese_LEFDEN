using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoutScoreEnnemie : MonoBehaviour
{
    private GestionUiJeux gestionUiJeux;

    // Start is called before the first frame update
    void Start()
    {
        // Assurez-vous que gestionUiJeux est initialisé en recherchant l'objet dans la scène
        gestionUiJeux = FindObjectOfType<GestionUiJeux>();

        // Vérifiez si l'objet a été trouvé avant d'appeler la méthode
        if (gestionUiJeux != null)
        {
            gestionUiJeux.AugmenterEnnemiAbattu();
        }
        else
        {
            Debug.LogError("GestionUiJeux not found in the scene.");
        }
    }
}
