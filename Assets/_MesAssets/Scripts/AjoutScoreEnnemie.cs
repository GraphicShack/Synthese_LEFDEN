using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AjoutScoreEnnemie : MonoBehaviour
{
    private GestionUiJeux gestionUiJeux;
    // Start is called before the first frame update
    void Start()
    {
        gestionUiJeux.AugmenterEnnemiAbattu();
    }
}