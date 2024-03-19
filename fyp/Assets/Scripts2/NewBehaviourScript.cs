using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Color flashColor = new Color(1f, 0.5f, 0.5f, 0.5f);
    public float flashDuration = 0.5f;
    public float transitionDuration = 0.25f;

    private Color originalColor; 
    private Image bgImg; 
    private SpriteRenderer rendererComponent;

    private void Start()
    {
        bgImg = GetComponent<Image>();
        rendererComponent = GetComponent<SpriteRenderer>();

        if (rendererComponent != null)
            originalColor = rendererComponent.material.color;
        else if (bgImg != null)
            originalColor = bgImg.color;

        StartCoroutine(FlashBackground());
    }

    // private System.Collections.IEnumerator FlashBackground()
    // {
    //     while (true)
    //     {
    //         // Flash to the specified color
    //         bgImg.color = flashColor;
            
    //         // Wait for the specified duration
    //         yield return new WaitForSeconds(flashDuration);
            
    //         // Return back to the original color
    //         bgImg.color = originalColor;
            
    //         // Wait for the specified duration
    //         yield return new WaitForSeconds(flashDuration);
    //     }
    // }

    private System.Collections.IEnumerator FlashBackground()
    {
        while (true)
        {
            // Transition to the flash color
            yield return StartCoroutine(TransitionColor(flashColor, transitionDuration));

            // Wait for the specified duration
            yield return new WaitForSeconds(flashDuration);

            // Transition back to the original color
            yield return StartCoroutine(TransitionColor(originalColor, transitionDuration));

            // Wait for the specified duration
            yield return new WaitForSeconds(flashDuration);
        }
    }

    private System.Collections.IEnumerator TransitionColor(Color targetColor, float duration)
    {
        Color startColor;
        if (rendererComponent != null)
            startColor = rendererComponent.material.color;
        else
            startColor = bgImg.color;

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);

            if (rendererComponent != null)
                rendererComponent.material.color = Color.Lerp(startColor, targetColor, t);
            else
                bgImg.color = Color.Lerp(startColor, targetColor, t);

            yield return null;
        }

        if (rendererComponent != null)
            rendererComponent.material.color = targetColor;
        else
            bgImg.color = targetColor;
    }

}
