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
    public bool answeredCorrectly;

    [Header("Answer Sprites")]
    [SerializeField] Sprite defaultAnsSprite;
    //default anssprite color: #09FFA0 
    [SerializeField] Sprite correctAnsSprite;

    [Header("Timer")]
    [SerializeField] Image timerSprite;
    TimerController timer;

    void Start()
    {
        timer = FindObjectOfType<TimerController>();
    }

    void Update()
    {
        timerSprite.fillAmount = timer.fillFraction;
        if(timer.loadNextQuestion)
        {
            answeredEarly = false;
            ShowNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if(!answeredEarly && !timer.isAnsweringQuestion)
        {
            ShowAnswer(-1);
            ChangeButtonState(false);
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
            answeredCorrectly = true;
            btnImage = answerBtns[index].GetComponent<Image>();
            btnImage.sprite = correctAnsSprite;
            btnImage.color = Color.white;
            
        }
        else
        {
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

    void ShowNextQuestion()
    {
        if(questions.Count > 0)
        {
            ChangeButtonState(true);
            ResetButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }
        else
        {

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
