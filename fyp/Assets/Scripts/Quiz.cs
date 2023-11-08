using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerBtns;
    int correctAnsIndex;
    bool answeredEarly;

    //for game controller
    public bool answeredCorrectly = false;
    GameController gameController;
   

    [Header("Answer Sprites")]
    [SerializeField] Sprite defaultAnsSprite;
    //default anssprite color: #09FFA0 
    [SerializeField] Sprite correctAnsSprite;

    [Header("Timer")]
    [SerializeField] Image timerSprite;
    public TimerController timer;

    public bool gameStarted = false;

    //index of the current box
    int currentBox = -1;

    void Start()
    {
        // if(gameStarted)
        // {
        //     questionText.enabled = true;
        //     for (int i = 0; i < answerBtns.Length; i++)
        //     {
        //         answerBtns[i].gameObject.SetActive(true);
        //     }
        //     timer = FindObjectOfType<TimerController>();
        // }
        // else
        // {
            questionText.enabled = false;
            for (int i = 0; i < answerBtns.Length; i++)
            {
                answerBtns[i].gameObject.SetActive(false);
            }
        // }
    }

    void Update()
    {
        if(gameStarted)
        {
            questionText.enabled = true;
            for (int i = 0; i < answerBtns.Length; i++)
            {
                answerBtns[i].gameObject.SetActive(true);
            }
            timer = FindObjectOfType<TimerController>();
            gameController = FindObjectOfType<GameController>();
            timerSprite.fillAmount = timer.fillFraction;
            // if(timer.loadNextQuestion)
            // {
            //     answeredEarly = false;
            //     ShowNextQuestion();
            //     timer.loadNextQuestion = false;
            // }
            if(!answeredEarly && !timer.isAnsweringQuestion)
            {
                ShowAnswer(-1);
                ChangeButtonState(false);

                Debug.Log("Currentbox: " + currentBox);
                if(currentBox >= 0)
                {
                    gameController.PlaceMark(currentBox, false);
                }
            }
        }
        
    }

    public void OnAnswerSelected(int index)
    {
        answeredEarly = true;
        ShowAnswer(index);
        ChangeButtonState(false);
        timer.CancelTimer();
    }

    void ShowAnswer(int index)
    {

        Image btnImage;
        if(index == currentQuestion.GetCorrectAnswerIndex())
        {
            questionText.text = "Correct!";

            Debug.Log("Currentbox: " + currentBox);
            if(currentBox >= 0)
            {
                gameController.PlaceMark(currentBox, true);
            }
            

            answeredCorrectly = true;
            btnImage = answerBtns[index].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
            btnImage.color = Color.white;
            
        }
        else
        {
            Debug.Log("Currentbox: " + currentBox);
            if(currentBox >= 0)
            {
                gameController.PlaceMark(currentBox, false);
            }


            answeredCorrectly = false;
            correctAnsIndex = currentQuestion.GetCorrectAnswerIndex();
            string correctAnswer = currentQuestion.GetAnswer(correctAnsIndex);
            questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
            btnImage = answerBtns[correctAnsIndex].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
            btnImage.color = Color.white;
            
        }
    }

    void ChangeButtonState(bool state)
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            answerBtns[i].GetComponent<Button>().interactable = state;
        }
    }

    public void ShowNextQuestion(int index)
    {
        currentBox = index;

        if(questions.Count > 0)
        {
            answeredEarly = false;
            timer = FindObjectOfType<TimerController>();
            timer.ResetTimer();
            ChangeButtonState(true);
            ResetButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }
        else
        {
            //end of quiz
        }
         
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    void ResetButtonSprites()
    {
        for (int i = 0; i < answerBtns.Length; i++)
        {
            answerBtns[i].GetComponent<Image>().sprite = defaultAnsSprite;
            answerBtns[i].GetComponent<Image>().color = new Color(0.035f, 1f, 0.627f);
        }
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for (int i = 0; i < answerBtns.Length; i++)
        {
            TextMeshProUGUI buttonText = answerBtns[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }

    


}
