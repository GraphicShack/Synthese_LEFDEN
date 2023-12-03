using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptMenuInstruction : MonoBehaviour
{

    public GameObject instructionPanel;
    public GameObject mainPanel;


    public void Retour()
    {
        // D�sactiver le panel des instructions
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
        }

        // Activer le panel principal
        if (mainPanel != null)
        {
            mainPanel.SetActive(true);
        }
    }

}
