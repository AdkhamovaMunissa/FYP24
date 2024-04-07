using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireController2 : MonoBehaviour
{
    public Button NextBtn;
    public Button VideoBtn;
    public Button RightBtn;
    public Button LeftBtn;
    public GameObject FireExtinguisher;
    

    public string step;
    public RawImage videoRawImage;
    public GameObject videoPlayerObject;
    private bool videoPlaying = false;
    public GameObject dialogBoxStep1;
    DialogueController dialogController1;
  
    void Start()
    {
        videoRawImage.enabled = false;
        videoPlayerObject.SetActive(false);

        NextBtn.interactable = false;
        NextBtn.image.enabled = false;

        VideoBtn.interactable = false;
        VideoBtn.image.enabled = false;

        dialogController1 = dialogBoxStep1.GetComponent<DialogueController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (dialogController1.Index == dialogController1.Sentences.Length)
        {
            VideoBtn.interactable = true;
            VideoBtn.image.enabled = true;
        }

        if (true)
        {
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
            videoRawImage.enabled = false;
            videoPlayerObject.SetActive(false);
        }
    }

}
