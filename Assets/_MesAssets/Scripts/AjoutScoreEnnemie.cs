using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoutScoreEnnemie : MonoBehaviour
{
    private GestionUiJeux gestionUiJeux;

    // Start is called before the first frame update
    void Start()
    {
        // Assurez-vous que gestionUiJeux est initialis� en recherchant l'objet dans la sc�ne
        gestionUiJeux = FindObjectOfType<GestionUiJeux>();

        // V�rifiez si l'objet a �t� trouv� avant d'appeler la m�thode
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
