using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class FireController : MonoBehaviour
{
    public Image image;
    public float flashDuration = 0.2f;
    public float flashInterval = 0.4f;

    private bool isFlashing = false;
    private Color originalColor;
    private Coroutine flashCoroutine;


    //Fields for Alarm Drop

    private bool AlarmActivated = false;

    public Button NextBtn;


    //Fields of other scripts
    public GameObject alarmSlot;
    public GameObject dialogBox;
    CheckDrop checkDrop;
    DialogueController dialogController;



    private void Start()
    {
        checkDrop = alarmSlot.GetComponent<CheckDrop>();
        dialogController = dialogBox.GetComponent<DialogueController>();

        Debug.Log("alarmActivated: " + checkDrop.OnDropSuccess);

        // Get the original color of the image
        originalColor = image.color;

        // Start the flashing coroutine
        StartFlashing();

        //Disable the Next button until the alarm is not placed in the slot
        NextBtn.interactable = false;
        NextBtn.image.enabled = false;
    }

    private void Update() {

        if (checkDrop.OnDropSuccess && dialogController.Index == dialogController.Sentences.Length)
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

}
