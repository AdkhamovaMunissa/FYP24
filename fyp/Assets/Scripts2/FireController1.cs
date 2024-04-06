using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireController1 : MonoBehaviour
{
    public Button NextBtn;
    public Button VideoBtn;
    public RawImage videoRawImage;
    public GameObject videoPlayerObject;
    private bool videoPlaying = false;
    public GameObject dialogBoxStep1;
    public GameObject dialogBoxStep2;
    DialogueController dialogController1;
    DialogueController dialogController2;
    void Start()
    {
        videoRawImage.enabled = false;
        videoPlayerObject.SetActive(false);
        //ActionScreen.enabled = false;

        NextBtn.interactable = false;
        NextBtn.image.enabled = false;

        VideoBtn.interactable = false;
        VideoBtn.image.enabled = false;

        dialogBoxStep2.SetActive(false);

        dialogController1 = dialogBoxStep1.GetComponent<DialogueController>();
        dialogController2 = dialogBoxStep2.GetComponent<DialogueController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (dialogController1.Index == dialogController1.Sentences.Length)
        {
            VideoBtn.interactable = true;
            VideoBtn.image.enabled = true;
            dialogBoxStep1.SetActive(false);
            dialogBoxStep2.SetActive(true);
        }
    }

    public void ToggleVideoPlayback()
    {
        videoPlaying = !videoPlaying;

        if (videoPlaying)
        {
            // Enable the RawImage component to make the video appear
            //ActionScreen.enabled = true;
            videoRawImage.enabled = true;
            videoPlayerObject.SetActive(true);
            // TODO: Play the video
        }
        else
        {
            // Disable the RawImage component to hide the video
            videoRawImage.enabled = false;
            videoPlayerObject.SetActive(false);
            // TODO: Stop or pause the video
        }
    }
}
