using System.Collections;
using UnityEngine;

public class MouvementPowerUp : MonoBehaviour
{
    private float minSpeed = 1.5f;
    private float maxSpeed = 2.0f;
    private float currentSpeed;
    public float stopXCoordinate = -8.0f;

    private GestionTir gestionTir;

    private void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        InvokeRepeating("IncreaseSpeed", 20.0f, 20.0f);
    }

    void Update()
    {
        MoveRightToLeft();

        // Check if the object reaches X = -8
        if (transform.position.x <= stopXCoordinate)
        {
            // Call the rapid fire function from the GestionTir script
            if (gestionTir != null)
            {
                gestionTir.ActiverTirRapide();
            }

            // Destroy the object since the rapid fire function has been called
            Destroy(gameObject);
        }
    }

    void MoveRightToLeft()
    {
        float movement = currentSpeed * Time.deltaTime;
        transform.Translate(Vector3.left * movement);
    }

    void IncreaseSpeed()
    {
        currentSpeed = Mathf.Min(currentSpeed + 0.25f, 3.5f);
    }
}
