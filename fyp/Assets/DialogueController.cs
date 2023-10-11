using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;    //reference to the text
    public string[] Sentences;  // making this string so we have multiple sentences in the dialogue
    private int Index = 0;
    public float DialogueSpeed;
    public Animator DialogueAnimator;
    private bool StartDialogue = true;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            if (StartDialogue)
            {
                DialogueAnimator.SetTrigger("Enter");
                StartDialogue = false;
            }
            else
            {
                NextSentence();
            }
        }     
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
            DialogueText.text = "";
            DialogueAnimator.SetTrigger("Exit");
            Index = 0;
            StartDialogue = true;
        }
    }


    IEnumerator WriteSentence()
    {
        foreach(char Charachter in Sentences[Index].ToCharArray())
        {
            DialogueText.text += Charachter;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        Index++;
    }


}
