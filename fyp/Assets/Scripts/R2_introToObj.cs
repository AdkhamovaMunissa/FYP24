using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R2_introToObj : MonoBehaviour
{
    public GameObject dialogBox;
    DialogManagerEmp dialogManager;
    public GameObject nextBtn;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogManager = dialogBox.GetComponent<DialogManagerEmp>();
        nextBtn = GameObject.Find("NextBtn");

        if( dialogManager != null) 
        {
            int index = dialogManager.Index;
            Debug.Log("Successfully fetched the index: "  + index);
        }

        SetObjectsActive(nextBtn, false);
    }

    // Update is called once per frame
    void Update()
    {
        int index = dialogManager.Index;
        int length = dialogManager.Sentences.Length;
        if(index == length)
        {
            SetObjectsActive(nextBtn, true);
        }
        //Debug.Log("Successfully fetched the index: "  + index);
    }

    private void SetObjectsActive(GameObject gameObject, bool activeState)
    {
        gameObject.SetActive(activeState);
    }
}
