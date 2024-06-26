using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;    //reference to the text
    public string[] Sentences;  // making this string so we have multiple sentences in the dialogue
    public int Index = 0;
    public float DialogueSpeed;
    bool nextMessageCoroutine = false;

    
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

    void NextSentence()
    {
        if(Index <= Sentences.Length - 1)
        {
            DialogueText.text = "";
            
            StartCoroutine(WriteSentence());
           
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
}
