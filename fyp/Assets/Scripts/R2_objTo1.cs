using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2_objTo1 : MonoBehaviour
{
    public GameObject dialogBox;
    DialogueController dialogManager;
    public GameObject startBtn;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogBox.GetComponent<DialogueController>();
        startBtn = GameObject.Find("StartBtn");

        if( dialogManager != null) 
        {
            int index = dialogManager.Index;
            Debug.Log("Successfully fetched the index: "  + index);
        }

        SetObjectsActive(startBtn, false);
    }

    // Update is called once per frame
    void Update()
    {
        int index = dialogManager.Index;
        int length = dialogManager.Sentences.Length;
        if(index == length)
        {
            SetObjectsActive(startBtn, true);
        }
        //Debug.Log("Successfully fetched the index: "  + index);
    }

    private void SetObjectsActive(GameObject gameObject, bool activeState)
    {
        gameObject.SetActive(activeState);
    }
}
