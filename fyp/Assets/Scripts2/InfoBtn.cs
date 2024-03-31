using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InfoBtn : MonoBehaviour
{

    public GameObject DialogBox;
    public Button toggleButton;

    private bool isDialogBoxActive = false;

    public TextMeshProUGUI DialogueText;    //reference to the text
    public string[] Sentences;  // making this string so we have multiple sentences in the dialogue
    public int Index = 0;
    public float DialogueSpeed;
    bool nextMessageCoroutine = false;

    private void Start()
    {
        // Disable the object initially
        DialogBox.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
    
    void Update()
    {
        EventSystem.current.SetSelectedGameObject(null);
        // if(nextMessageCoroutine){
        //     return;
        // }

        // if(isDialogBoxActive && Input.GetKeyDown(KeyCode.Space) && !nextMessageCoroutine)
        // {   
        //     NextSentence();
        // }

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
            // DialogBox.SetActive(false);
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

    public void ToggleGameObject()
    {
        // Toggle the active state of the object
        Debug.Log("Toggle activated!");
        isDialogBoxActive = !isDialogBoxActive;
        DialogBox.SetActive(isDialogBoxActive);
        Index = 0;
        NextSentence();
    }

    public void NextBtn(string nextScene) 
    {
        if(Index == Sentences.Length)
        {
            SceneManager.LoadScene(nextScene);
        }
        if(nextMessageCoroutine){
            return;
        }

        if(isDialogBoxActive && !nextMessageCoroutine)
        {   
            NextSentence();
        }
    }

      public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
