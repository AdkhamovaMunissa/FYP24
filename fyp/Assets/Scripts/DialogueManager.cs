using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;    //reference to the text
    public string[] Sentences;  // making this string so we have multiple sentences in the dialogue
    private int Index = 0;
    public float DialogueSpeed;
    bool nextMessageCoroutine = false;

    public GameObject complianceBtns;
    public GameObject dialogBox;

    
    void Update()
    {
        if(nextMessageCoroutine){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) && !nextMessageCoroutine)
        {   
            NextSentence();
        }

    }

    void Start()
    {
        complianceBtns = GameObject.Find("ComplianceBtns");
        dialogBox = GameObject.Find("DialogBox");

        SetObjectsActive(complianceBtns, false);
        SetObjectsActive(dialogBox, true);
    }

    void NextSentence()
    {
        if(Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            
            StartCoroutine(WriteSentence());
        }
        else
        {
            SetObjectsActive(complianceBtns, true);
            SetObjectsActive(dialogBox, false);
        }
    }

    IEnumerator WriteSentence()
    {
        nextMessageCoroutine = true;
            foreach(char Charachter in Sentences[Index].ToCharArray())
            {
            
                DialogueText.text += Charachter;
                yield return new WaitForSeconds(DialogueSpeed);
            }
            Index++;
        nextMessageCoroutine = false;
    }

    private void SetObjectsActive(GameObject gameObject, bool activeState)
    {
        gameObject.SetActive(activeState);
    }
}
