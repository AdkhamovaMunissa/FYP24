using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class GameController : MonoBehaviour
{
    static Button[] boxes = new Button[9];
    static int[] cellValues = new int[9];
    public Sprite crossImage;
    public Sprite tickImage;
    public GameObject question;

    [Header("Windows")]
    [SerializeField] GameObject gameWindow;
    [SerializeField] GameObject gameOverWindow;
    [SerializeField] GameObject pauseWindow;

    [Header("Win elements")]
    [SerializeField] TextMeshProUGUI winMessage;
    [SerializeField] GameObject starsBar;
    private SpriteRenderer[] stars;

    [Header("Window Btns")]
    [SerializeField] Button pauseBtn;
    // [SerializeField] Button CloseBtn;
    
    static Quiz quiz;
    public CloseWindow closeWindow;
    static TimerController timer;


    // Start is called before the first frame update
    void Start()
    {
        

        if(question != null)
        {
            quiz = question.GetComponent<Quiz>();
            timer = quiz.timer;
        }
        else 
        {
            Debug.Log("question object not assigned");
        }
        
        
        for(int i=0; i<9; i++)
        {
            // boxes[i] = GameObject.Find("Token (" + (i+1) + ")").GetComponent<Button>();
            boxes[i].GetComponent<Image>().enabled = false;
            
            Debug.Log("Buttons assigned");
        }
    }

    private void Awake() {
        gameWindow.SetActive(true);
        gameOverWindow.SetActive(false);
        pauseWindow.SetActive(false);


        for(int i=0; i<9; i++)
        {
            boxes[i] = GameObject.Find("Token (" + (i+1) + ")").GetComponent<Button>();
            cellValues[i] = -1;
        }

        stars = starsBar.GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int winner = -1;
        for(int player = 0; player < 2; player++){

            // Check rows
            for (int row = 0; row < 9; row += 3)
            {
                if (cellValues[row] == player && cellValues[row + 1] == player && cellValues[row + 2] == player)
                {
                    winner = player;
                    Debug.Log("Player " + player + "wins"); // Player has won in the current row
                    GameOver(player);
                }
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (cellValues[col] == player && cellValues[col + 3] == player && cellValues[col + 6] == player)
                {
                    winner = player;
                    Debug.Log("Player " + player + "wins"); // Player has won in the current column
                    GameOver(player);
                }
            }

            // Check diagonals
            if ((cellValues[0] == player && cellValues[4] == player && cellValues[8] == player) ||
                (cellValues[2] == player && cellValues[4] == player && cellValues[6] == player))
            {
                winner = player;
                Debug.Log("Player " + player + "wins"); // Player has won in any of the diagonals
                GameOver(player);
            }
        }
        
        if(!cellValues.Contains(-1) && winner == -1)
        {
            Debug.Log("It is a tie!");
            GameOver(-1);
        }


    }

    public void Move(int index){
            Debug.Log("From Btn player: " + cellValues[index]);
            quiz.gameStarted = true;
            
            if (boxes[index] != null && cellValues[index] == -1)
            {
                SetGrid(false);
                quiz.ShowNextQuestion(index);
                //StartCoroutine(WhileAnswering());
                boxes[index].GetComponent<Image>().enabled = true;
                Debug.Log("Box " + (index+1) + " has been assigned correctly with a Button component.");
                Debug.Log("isAnswering questions " + quiz.timer.isAnsweringQuestion);

            }
            else if (cellValues[index] >= 0){
                Debug.Log("Works statically" + cellValues[index]);
            }
             
    }

    public void PlaceMark(int index, bool correct, int questions)
    {
        //increase the opacity of the mark
        Color color = boxes[index].GetComponent<Image>().color;
        color.a = 1;
        boxes[index].GetComponent<Image>().color = color;

        stars = starsBar.GetComponentsInChildren<SpriteRenderer>();

        if(correct)
        {
            boxes[index].GetComponent<Image>().sprite = tickImage;
            cellValues[index] = 0;

            // if(questions <= 4)
            // {
            //     stars[0].color = Color.white;
            //     stars[1].color = Color.white;
            //     stars[2].color = Color.white;
            //     Debug.Log("3 stars!");
            // }
            // else if(questions <= 7)
            // {
            //     stars[0].color = Color.white;
            //     stars[1].color = Color.white;
            //     stars[2].color = new Color(0.32f, 0.32f, 0.32f);
            //     Debug.Log("2 stars!");
            // }
            // else
            // {
            //     stars[0].color = Color.white;
            //     stars[1].color = new Color(0.32f, 0.32f, 0.32f);
            //     stars[2].color = new Color(0.32f, 0.32f, 0.32f);
            //     Debug.Log("1 star!");
            // }

        }
        else
        {
            boxes[index].GetComponent<Image>().sprite = crossImage;
            // stars[0].color = new Color(0.32f, 0.32f, 0.32f);
            // stars[1].color = new Color(0.32f, 0.32f, 0.32f);
            // stars[2].color = new Color(0.32f, 0.32f, 0.32f);
            cellValues[index] = 1;
        }

        SetGrid(true);
    }

    public void GameOver(int winner) {
        
        SetGrid(false);

        //gameWindow.SetActive(false);
        gameOverWindow.SetActive(true);
        int questions = 9 - quiz.questions.Count;

        if(winner == 0)
        {
            winMessage.text = "Congratulations! You mastered this round!";
            if(questions <= 4)
            {
                stars[0].color = Color.white;
                stars[1].color = Color.white;
                stars[2].color = Color.white;
                Debug.Log("3 stars!");
            }
            else if(questions <= 7)
            {
                stars[0].color = Color.white;
                stars[1].color = Color.white;
                stars[2].color = new Color(0.32f, 0.32f, 0.32f);
                Debug.Log("2 stars!");
            }
            else
            {
                stars[0].color = Color.white;
                stars[1].color = new Color(0.32f, 0.32f, 0.32f);
                stars[2].color = new Color(0.32f, 0.32f, 0.32f);
                Debug.Log("1 star!");
            }
        }
        else if (winner == 1)
        {
            winMessage.text = "Sorry, you lost :(";
            stars[0].color = new Color(0.32f, 0.32f, 0.32f);
            stars[1].color = new Color(0.32f, 0.32f, 0.32f);
            stars[2].color = new Color(0.32f, 0.32f, 0.32f);
        }
        else 
        {
            winMessage.text = "It's a tie. Try again?";
            stars[0].color = new Color(0.32f, 0.32f, 0.32f);
            stars[1].color = new Color(0.32f, 0.32f, 0.32f);
            stars[2].color = new Color(0.32f, 0.32f, 0.32f);
        }
        Debug.Log("Questions: " + quiz.questions.Count);

    }

    public void SetGrid(bool state)
    {
        for(int i=0; i<9; i++)
        {
            boxes[i].enabled = state;
        }
    }

    public void ChangeWindow()
    {
        closeWindow = gameOverWindow.GetComponent<CloseWindow>();
        closeWindow.SetWindow();
        // windowToShow.SetActive(true);
    }

    public void Pause()
    {
        quiz.PauseTimer();
        pauseWindow.SetActive(true);
        Debug.Log("Pause called");
    }

    public void Resume()
    {
        quiz.ResumeTimer();
        pauseWindow.SetActive(false);
        Debug.Log("Resume called");
    }
}
