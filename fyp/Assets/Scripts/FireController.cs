using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class FireController : MonoBehaviour, IDropHandler
{
    public Image image;
    public float flashDuration = 0.2f;
    public float flashInterval = 0.4f;

    private bool isFlashing = false;
    private Color originalColor;
    private Coroutine flashCoroutine;

    public GameObject correctObject; // The correct object to be dropped on the slot

    private bool AlarmActivated = false;

    public Button NextBtn;


    private void Start()
    {
        // Get the original color of the image
        originalColor = image.color;

        // Start the flashing coroutine
        StartFlashing();
        NextBtn.interactable = false;
        NextBtn.image.enabled = false;
    }

    private void Update() {

        if (AlarmActivated)
        {
            NextBtn.interactable = true;
            NextBtn.image.enabled = true;
        }
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

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            // Check if the correct object is dropped on the slot
            if (eventData.pointerDrag.gameObject == correctObject)
            {
                AlarmActivated = true;
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
}
