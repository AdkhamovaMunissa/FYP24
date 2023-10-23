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
    private ComputerPlayer computerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        computerPlayer = gameController.GetComponent<ComputerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        if (computerPlayer.counter < 9)
        {
            image.enabled = true;
            image.sprite = images[1];
            Debug.Log("Clicked");
            computerPlayer.PlaceCross();
            computerPlayer.counter++;
            Debug.Log("Tictactoe player: " + computerPlayer.counter);
        }
    }

    private void Awake() {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        image = GetComponent<Image>();
    }

}
