using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManagerEmp : MonoBehaviour
{
    public TextMeshProUGUI DialogueTextEmp;    //reference to the text
    public TextMeshProUGUI DialogueTextManager; 
    public string[] Sentences;  // making this string so we have multiple sentences in the dialogue
    public int[] currentSpeaker; // 0 for employee, 1 for manager
    public int Index = 0;
    public float DialogueSpeed;
    bool nextMessageCoroutine = false;

    public GameObject dialogBoxManager;
    public GameObject dialogBoxEmp;

    
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
        dialogBoxManager = GameObject.Find("DialogBoxManager");
        dialogBoxEmp = GameObject.Find("DialogBoxEmp");

        NextSentence();
        if(currentSpeaker[Index] == 1)
        {
            SetObjectsActive(dialogBoxManager, true);
            SetObjectsActive(dialogBoxEmp, false);   
        }
        else
        {
            SetObjectsActive(dialogBoxManager, false);
            SetObjectsActive(dialogBoxEmp, true);
        }
        
    }

    void NextSentence()
    {
        if(Index <= Sentences.Length - 1)
        {
            if(currentSpeaker[Index] == 1)
            {
                SetObjectsActive(dialogBoxManager, true);
                DialogueTextManager.text = "";
                StartCoroutine(WriteSentence(DialogueTextManager));
                
                //SetObjectsActive(dialogBoxEmp, false);
            }
            else if (currentSpeaker[Index] == 0)
            {
                SetObjectsActive(dialogBoxEmp, true);
                DialogueTextEmp.text = "";
                StartCoroutine(WriteSentence(DialogueTextEmp)); 
                //SetObjectsActive(dialogBoxManager, false);
                
            }
            else 
            {
                
            }
        }
    }

    IEnumerator WriteSentence(TextMeshProUGUI dialogueText)
    {
        nextMessageCoroutine = true;
            foreach(char Charachter in Sentences[Index].ToCharArray())
            {
            
                dialogueText.text += Charachter;
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
