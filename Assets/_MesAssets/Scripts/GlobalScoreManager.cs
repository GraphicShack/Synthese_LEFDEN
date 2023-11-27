using UnityEngine;

public class GlobalScoreManager : MonoBehaviour
{
    public static int[] topScores = new int[5];

    void Awake()
    {
        // Assurez-vous que l'objet persiste entre les scènes
        DontDestroyOnLoad(gameObject);

        // Initialisation des scores à zéro au début du jeu
        for (int i = 0; i < topScores.Length; i++)
        {
            topScores[i] = 0;
        }
    }
}
