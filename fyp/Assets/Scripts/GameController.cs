using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    static Button[] boxes = new Button[9];
    static int[] cellValues = new int[9];
    public Sprite crossImage;
    public Sprite tickImage;
    public GameObject question;
    Quiz quiz;

    // Start is called before the first frame update
    void Start()
    {
        question.SetActive(false);
        for(int i=0; i<9; i++)
        {
            // boxes[i] = GameObject.Find("Token (" + (i+1) + ")").GetComponent<Button>();
            boxes[i].GetComponent<Image>().enabled = false;
            
            Debug.Log("Buttons assigned");
        }
    }

    private void Awake() {
        for(int i=0; i<9; i++)
        {
            boxes[i] = GameObject.Find("Token (" + (i+1) + ")").GetComponent<Button>();
            cellValues[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int player = 0; player < 2; player++){

            // Check rows
            for (int row = 0; row < 9; row += 3)
            {
                if (cellValues[row] == player && cellValues[row + 1] == player && cellValues[row + 2] == player)
                {
                    Debug.Log("Player " + player + "wins"); // Player has won in the current row
                    GameOver();
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (cellValues[col] == player && cellValues[col + 3] == player && cellValues[col + 6] == player)
                {
                    Debug.Log("Player " + player + "wins"); // Player has won in the current column
                    GameOver();
                }
            }

            // Check diagonals
            if ((cellValues[0] == player && cellValues[4] == player && cellValues[8] == player) ||
                (cellValues[2] == player && cellValues[4] == player && cellValues[6] == player))
            {
                Debug.Log("Player " + player + "wins"); // Player has won in any of the diagonals
                GameOver();
            }
        }
        
    }

    public void Move(int index){
            Debug.Log("From Btn player: " + cellValues[index]);
            if (boxes[index] != null && cellValues[index] == -1)
            {
                question.SetActive(true);
                boxes[index].GetComponent<Image>().enabled = true;
                Debug.Log("Box " + (index+1) + " has been assigned correctly with a Button component.");
                if(quiz.answeredCorrectly)
                {
                    boxes[index].GetComponent<Image>().sprite = tickImage;
                    cellValues[index] = 0;
                }
                else
                {
                    boxes[index].GetComponent<Image>().sprite = crossImage;
                    cellValues[index] = 1;
                }

            }
            else if (cellValues[index] >= 0){
                Debug.Log("Works statically" + cellValues[index]);
            }
             
    }

    public void GameOver() {
        for(int i=0; i<9; i++)
        {
            boxes[i].enabled = false;
        }
    }
}