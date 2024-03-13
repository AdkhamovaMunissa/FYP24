using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashBtn : MonoBehaviour
{
    public float flashDuration = 0.5f;
    public float flashInterval = 0.2f;

    private Button button;
    private Image buttonImage;
    private Color originalColor;
    private bool isFlashing = false;

    void Start()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();

        originalColor = buttonImage.color;
        StartFlashing();
    }

    public void StartFlashing()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            StartCoroutine(FlashCoroutine());
        }
    }

    public void StopFlashing()
    {
        if (isFlashing)
        {
            isFlashing = false;
            buttonImage.color = originalColor;
            StopAllCoroutines();
        }
    }

    private System.Collections.IEnumerator FlashCoroutine()
    {
        while (isFlashing)
        {
            buttonImage.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
            buttonImage.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.5f);
            yield return new WaitForSeconds(flashInterval);
        }
    }
}
