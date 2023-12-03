using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptRetourMenu : MonoBehaviour
{
    public void RetourAuMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
