using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Image characterImage;
    // public TextMeshProUGUI characterName;
    public GameObject nameBtn;
    public TextMeshProUGUI messageText;
    public RectTransform bgBox;

    Message[] currentMessages;
    Character[] currentCharacters;
    int activeMessage = 0;
    public static bool isActive = false;

    public Canvas introCanvas;
    public Canvas round2Canvas;

    public void OpenDialogue(Message[] messages, Character[] characters) {
        isActive = true;
        currentMessages =  messages;
        currentCharacters = characters;
        activeMessage = 0;

        Debug.Log("Started the convo" + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage() 
    {


        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Character characterToDisplay = currentCharacters[messageToDisplay.characterId];
        characterImage.sprite = characterToDisplay.sprite;

        TextMeshProUGUI buttonText = nameBtn.GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = characterToDisplay.name;
    }

    public void DisplayNextMessage() 
    {
        activeMessage++;
        if(activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else 
        {
            isActive = false;
            Debug.Log("End of script");
            // introCanvas.enabled = false;
            // round2Canvas.enabled = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // introCanvas.enabled = true;
        // round2Canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive)
        {
            DisplayNextMessage();
        }
    }
}
