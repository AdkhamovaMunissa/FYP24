using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeController : MonoBehaviour
{
    // SpriteRenderer spriteRenderer;
    Image image;
    public Sprite[] images;
    public GameObject gameController;
    public GameObject question;
    private ComputerPlayer computerPlayer;
    public int[] cellValues;
    

    // Start is called before the first frame update
    void Start()
    {
        computerPlayer = gameController.GetComponent<ComputerPlayer>();
        question.SetActive(false);
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if (computerPlayer.counter < 9)
        {
            question.SetActive(true);
            
            image.enabled = true;
            image.sprite = images[1];
            Debug.Log("Clicked");
            //computerPlayer.PlaceCross();
            computerPlayer.counter++;
            Debug.Log("Tictactoe player: " + computerPlayer.counter);
        }
    }

    private void Awake() {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }

}
