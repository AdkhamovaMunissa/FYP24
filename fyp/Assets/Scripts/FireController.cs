using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireController : MonoBehaviour
{
    public Image image;
    public float flashDuration = 0.2f;
    public float flashInterval = 0.4f;

    private bool isFlashing = false;
    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Start()
    {
        // Get the original color of the image
        originalColor = image.color;

        // Start the flashing coroutine
        StartFlashing();
    }

    private void StartFlashing()
    {
        if (!isFlashing)
        {
            // Start the flashing coroutine
            flashCoroutine = StartCoroutine(FlashImage());
        }
    }

    private IEnumerator FlashImage()
    {
        isFlashing = true;

        while (true)
        {
            // Set the image color to transparent
            image.color = Color.grey;

            // Wait for the specified duration
            yield return new WaitForSeconds(flashDuration);

            // Reset the image color to the original color
            image.color = originalColor;

            // Wait for the specified interval
            yield return new WaitForSeconds(flashInterval);
        }
    }

    public void StopFlashing()
    {
        if (isFlashing)
        {
            // Stop the flashing coroutine and reset the image color
            StopCoroutine(flashCoroutine);
            image.color = originalColor;
            isFlashing = false;
        }
    }
}
