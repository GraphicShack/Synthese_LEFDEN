using UnityEngine;
using System.Collections;


public class LaneChange : MonoBehaviour
{
    public Vector3 targetPosition;   // The position to slide towards
    public float slideDelay = 5.0f;  // The delay before sliding
    public float slideDuration = 1.0f; // The time it takes to slide to the target position

    private void Start()
    {
        // Start the Coroutine to slide after the specified delay
        StartCoroutine(SlideAfterDelay());
    }

    private IEnumerator SlideAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(slideDelay);

        // Check if the transform is not null before accessing position
        if (transform != null)
        {
            // Get the initial position of the GameObject
            Vector3 startPosition = transform.position;

            // Perform a smooth slide using Lerp
            float elapsedTime = 0.0f;
            while (elapsedTime < 1.0f)
            {
                // Update the position using Lerp
                if (transform != null)
                {
                    transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
                }

                // Increment the elapsed time based on the time it takes to slide
                elapsedTime += Time.deltaTime / slideDuration;

                // Wait for the next frame
                yield return null;
            }

            // Ensure the GameObject reaches the exact target position
            if (transform != null)
            {
                transform.position = targetPosition;
            }
        }
    }


}