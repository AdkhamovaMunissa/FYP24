using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireController1 : MonoBehaviour
{
    public Button NextBtn;
    public Button VideoBtn;
    public GameObject extinguishSlot;
    public Button PinBtn;
    public string step;
    public RawImage videoRawImage;
    public GameObject videoPlayerObject;
    private bool videoPlaying = false;
    public GameObject dialogBoxStep1;
    CheckDrop checkDrop;
    DialogueController dialogController1;
  
    //DialogueController dialogController2;
    void Start()
    {
        videoRawImage.enabled = false;
        videoPlayerObject.SetActive(false);
        //ActionScreen.enabled = false;

        NextBtn.interactable = false;
        NextBtn.image.enabled = false;

        VideoBtn.interactable = false;
        VideoBtn.image.enabled = false;

        PinBtn.interactable = false;

        //dialogBoxStep2.SetActive(false);
        dialogController1 = dialogBoxStep1.GetComponent<DialogueController>();
        checkDrop = extinguishSlot.GetComponent<CheckDrop>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (dialogController1.Index == dialogController1.Sentences.Length - 1)
        {
            VideoBtn.interactable = true;
            VideoBtn.image.enabled = true;
        }

        if (checkDrop.OnDropSuccess)
        {
            StartCoroutine(FadeOutButton());
            NextBtn.interactable = true;
            NextBtn.image.enabled = true;
        }
    }

    public void ToggleVideoPlayback()
    {
        videoPlaying = !videoPlaying;
        

        if (videoPlaying)
        {
            videoRawImage.enabled = true;
            videoPlayerObject.SetActive(true);
            
        }
        else
        {
            // Disable the RawImage component to hide the video
            videoRawImage.enabled = false;
            videoPlayerObject.SetActive(false);
        }
    }

    public void RemovePin()
    {
        Debug.Log("PinBtn is clicked");
        StartCoroutine(FadeOutButton());
    }

    private System.Collections.IEnumerator FadeOutButton()
    {
        float duration = 4f;
        float currentTime = 0f;

        // Get the button's image component
        Image buttonImage = PinBtn.GetComponent<Image>();

        // Store the initial color and alpha value
        Color initialColor = buttonImage.color;
        float initialAlpha = initialColor.a;

        // Calculate the target alpha value (fully transparent)
        float targetAlpha = 0f;

        while (currentTime < duration)
        {
            // Calculate the new alpha value based on the current time and duration
            float newAlpha = Mathf.Lerp(initialAlpha, targetAlpha, currentTime / duration);

            // Update the button's color with the new alpha value
            buttonImage.color = new Color(initialColor.r, initialColor.g, initialColor.b, newAlpha);

            currentTime += Time.deltaTime;
            yield return null;
        }

        // Deactivate the button game object to make it disappear completely
        PinBtn.gameObject.SetActive(false);
    }
}
